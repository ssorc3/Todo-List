import React from "react";
import { cleanup, fireEvent, render, screen } from "@testing-library/react";
import { Todo } from "../../components/Todo";

afterEach(cleanup);

test('Todo renders', async () => {
    const todoItem = { id: 0, description: "An example todo", completed: false };
    render(<Todo item={todoItem} setCompleted={async () => { }} />);

    expect(await screen.findByText("An example todo")).toBeInTheDocument();
    expect(screen.getByRole("button")).toHaveTextContent("Mark completed");
});

test('Completed todo renders', async () => {
    const todoItem = { id: 0, description: "An example todo", completed: true };
    render(<Todo item={todoItem} setCompleted={async () => { }} />);

    const description = await screen.findByText("An example todo");
    expect(description).toBeInTheDocument();
    expect(description).toHaveStyle("text-decoration: line-through");
    expect(screen.getByRole("button")).toHaveTextContent("Mark pending");
});

test('Button calls callback', () => {
    const callback = jest.fn();
    const todoItem = { id: 0, description: "An example todo", completed: false };
    render(<Todo item={todoItem} setCompleted={callback} />)

    const button = screen.getByRole("button");
    fireEvent.click(button);

    expect(callback).toHaveBeenCalledTimes(1);
});