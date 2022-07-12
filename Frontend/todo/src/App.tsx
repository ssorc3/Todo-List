import React, { useState, useEffect } from "react";
import { v4 as uuidv4 } from "uuid";
import { type TodoItem } from "./Types";
import PuffLoader from "react-spinners/PuffLoader";
import { TodoList } from "./components/TodoList";
import { TodoForm } from "./components/TodoForm";
import * as API from "./Api";
import "./App.css";

const Spinner: React.FC = () => {
  return (
    <div className="spinner-container">
      <PuffLoader color={"#000"} loading={true} size={50} />
    </div>
  )
};

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

const App: React.FC = () => {
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

  const addTodo = async (todo: TodoItem): Promise<void> => {
    await API.saveTodo(userId, todo);
    setTodos([...todos, todo]);
  }

  return (
    <div className="App">
      <header>
        <h1>Todo</h1>
      </header>
      <div className="container">
        {loading ?
          <Spinner />
          : <TodoList items={todos} />}
        <TodoForm addTodo={addTodo} />
      </div>
    </div>
  );
}

export default App;
