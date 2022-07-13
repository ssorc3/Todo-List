import { type TodoItem } from "./Types";
import axios, { Axios } from "axios";

const baseUrl = process.env.REACT_APP_BASE_URL;

const fetchTodos = async (userId: string): Promise<TodoItem[]> => {
    const response = await axios.get(`${baseUrl}/todos?userId=${userId}`);
    const todos = (await response.data) as TodoItem[];
    return todos;
};

const saveTodo = async (userId: string, todo: TodoItem): Promise<void> => {
    await axios.post(`${baseUrl}/todos`, { userId, ...todo });
}

const completeTodo = async (userId: string, todo: TodoItem, completed: boolean): Promise<void> => {
    await axios.put(`${baseUrl}/todos/${todo.id}`, { userId, completed })
}

export {
    fetchTodos,
    saveTodo,
    completeTodo
};