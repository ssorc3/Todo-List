import { type TodoItem } from "../Types";
import { Todo } from "./Todo"

type TodoListProps = {
    items: TodoItem[],
    setCompleted: (item: TodoItem, completed: boolean) => Promise<void>
}

const TodoList: React.FC<TodoListProps> = ({ items, setCompleted }) => {
    const completed = items.filter(x => x.completed);
    const uncompleted = items.filter(x => !x.completed);

    return (
        <div>
            <h2>Pending:</h2>
            {uncompleted.length ?
                uncompleted.map((item, index) => (
                    <Todo key={index} item={item} setCompleted={setCompleted} />
                ))
                : <p className="message">
                    You have no pending todos.
                </p>}
            <h2>Completed:</h2>
            {completed.map((item, index) => (
                <Todo key={index} item={item} setCompleted={setCompleted} />
            ))}
        </div>
    )
}

export {
    TodoList
};