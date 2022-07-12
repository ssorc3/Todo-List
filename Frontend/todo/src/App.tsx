import React, { useState, useEffect } from "react";
import { v4 as uuidv4 } from "uuid";
import { type TodoItem } from "./Types";
import PuffLoader from "react-spinners/PuffLoader";
import * as API from "./Api";
import "./App.css";

const Spinner: React.FC = () => {
  return (
    <div className="spinner-container">
      <PuffLoader color={"#000"} loading={true} size={50} />
    </div>
  )
}

const Todo: React.FC<TodoItem> = ({ description }) => {
  return (
    <div className="todo">
      {description}
    </div>
  )
}

type TodoListProps = {
  items: TodoItem[]
}

const TodoList: React.FC<TodoListProps> = ({ items }) => {
  return (
    <div>
      {items.length ?
        items.map((item, index) => (
          <Todo key={index} {...item} />
        ))
        : <h2 className="message">
          You have no todos yet.
        </h2>}
    </div>
  )
}

const getUserId = (): string => {
  const existing = localStorage.getItem("userId");
  if (!existing) {
    const uid = uuidv4().toString();
    localStorage.setItem("userId", uid);
    return uid;
  } else {
    return existing;
  }
}

const App = () => {
  const userId = getUserId();
  const [todos, setTodos] = useState<TodoItem[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    const getData = async () => {
      const response = await API.fetchTodos(userId);
      setTodos(response);
      setLoading(false);
    };
    getData();
  }, [userId, setTodos])

  return (
    <div className="App">
      <header>
        <h1>Todo</h1>
      </header>
      <div className="container">
        {loading ?
          <Spinner />
          : <TodoList items={todos} />}
      </div>
    </div>
  );
}

export default App;
