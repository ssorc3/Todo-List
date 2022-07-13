import { type TodoItem } from "../Types";

type TodoProps = {
    item: TodoItem,
    setCompleted: (item: TodoItem, completed: boolean) => Promise<void>
}

const Todo: React.FC<TodoProps> = ({ item, setCompleted }) => {
    const { description, completed } = item;
    const style = {
        textDecoration: (completed ? "line-through" : "none")
    }
    return (
        <div className={"todo"}>
            <div className="description" style={style}>{description}</div>
            <button onClick={() => setCompleted(item, !completed)}>{completed ? "Mark pending" : "Mark completed"}</button>
        </div>
    )
};

export {
    Todo
};