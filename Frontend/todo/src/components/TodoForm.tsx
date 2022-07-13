import React, { useState, useEffect } from "react";
import { type TodoItem } from "../Types";

type TodoFormProps = {
    addTodo: (todo: TodoItem) => Promise<void>,
}

const TodoForm: React.FC<TodoFormProps> = ({ addTodo }) => {
    const [value, setValue] = useState<string>("");
    const [error, setError] = useState<boolean>();
    useEffect(() => {
        const listener = (event: KeyboardEvent) => {
            if (event.code === "Enter" || event.code === "NumpadEnter") {
                event.preventDefault();
                submit();
            }
        };
        document.addEventListener("keydown", listener);
        return () => {
            document.removeEventListener("keydown", listener);
        }
    })

    const submit = async () => {
        if (value === "") return;
        setError(false);
        try {
            await addTodo({ id: 0, description: value, completed: false })
            setValue("");
        } catch (e: any) {
            setError(true);
            console.log(e);
        }
    }

    const buttonDisabled = value === "";

    return (
        <div>
            <div className="todo-form">
                <input className="text-input" type="text" placeholder="Enter a new todo" value={value} onChange={e => setValue(e.target.value)} />
                <button className={buttonDisabled ? "disabled" : ""} disabled={buttonDisabled} onClick={submit}>Add</button>
            </div>
            {error && <div className="error-message">There was an error saving the todo. Please try again.</div>}
        </div>
    )
}

export {
    TodoForm
};