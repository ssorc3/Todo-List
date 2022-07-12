import { type TodoItem } from "./Types";
import env from "react-dotenv";

const baseUrl = env.BASE_URL;

const fetchTodos = async (userId: string): Promise<TodoItem[]> => {
    const response = await fetch(`${baseUrl}/todos?userId=${userId}`);
    const todos = (await response.json()) as TodoItem[];
    return todos;
};

export {
    fetchTodos
};