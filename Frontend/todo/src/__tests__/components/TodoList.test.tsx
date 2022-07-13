import React from "react";
import { cleanup, render, screen } from "@testing-library/react";
import { TodoList } from "../../components/TodoList";

afterEach(cleanup);

it("list renders correctly", async () => {
    const list = (<TodoList items={[]} setCompleted={async () => { }} />);
    render(list);

    expect(screen.getAllByRole("heading")[0]).toHaveTextContent("Pending:");
    expect(screen.getAllByRole("heading")[1]).toHaveTextContent("Completed:");
    expect(await screen.findByText("You have no pending todos.")).toBeInTheDocument();
});