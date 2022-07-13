import React from "react";
import { render, screen } from "@testing-library/react";
import { cleanup } from "@testing-library/react";
import App from "../App";

afterEach(cleanup);

it('app renders', () => {
    render(<App />);

    expect(screen.getByRole("heading")).toHaveTextContent(/Todo/);
});

