import { type TodoItem } from "../Types";
import { Todo } from "./Todo"

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

export {
    TodoList
};