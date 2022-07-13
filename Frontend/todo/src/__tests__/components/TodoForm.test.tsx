import React from "react";
import { cleanup, fireEvent, render, screen } from "@testing-library/react";
import { TodoForm } from "../../components/TodoForm";
import { act } from "react-dom/test-utils";

afterEach(cleanup);

it("TodoForm renders correctly", async () => {
    render(<TodoForm addTodo={async () => { }} />);

    const textbox = screen.getByRole("textbox");
    expect(textbox).toBeInTheDocument();
    expect(textbox).toHaveProperty("placeholder", "Enter a new todo");

    const button = screen.getByRole("button");
    expect(button).toBeInTheDocument();
    expect(button).toBeDisabled();
});

it("TodoForm button enabled when text is entered", () => {
    render(<TodoForm addTodo={async () => { }} />);

    const textbox = screen.getByRole("textbox");
    fireEvent.change(textbox, { target: { value: "An example todo" } });

    const button = screen.getByRole("button");
    expect(button).toBeEnabled();
});

test("Clicking add calls the callback", async () => {
    const promise = Promise.resolve();
    const callback = jest.fn(() => promise);
    const wrapper = render(<TodoForm addTodo={callback} />);

    const textbox = screen.getByRole("textbox");
    const button = screen.getByRole("button");
    act(() => {
        fireEvent.change(textbox, { target: { value: "An example todo" } });
        fireEvent.click(button);
    });

    await act(async () => await promise);

    expect(callback).toHaveBeenCalledTimes(1);
});

test("Pressing enter calls the callback", async () => {
    const promise = Promise.resolve();
    const callback = jest.fn(() => promise);
    const wrapper = render(<TodoForm addTodo={callback} />);

    const textbox = screen.getByRole("textbox");
    const button = screen.getByRole("button");
    act(() => {
        fireEvent.change(textbox, { target: { value: "An example todo" } });
        fireEvent.keyDown(textbox, {
            key: "Enter",
            code: "Enter",
            keyCode: 13,
            charCode: 13
        })
    });

    await act(async () => await promise);

    expect(callback).toHaveBeenCalledTimes(1);
})