import { type TodoItem } from "../Types";

const Todo: React.FC<TodoItem> = ({ description }) => {
    return (
        <div className="todo">
            {description}
        </div>
    )
};

export {
    Todo
};