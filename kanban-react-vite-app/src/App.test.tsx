import { describe, expect, it } from "vitest";
import { render, screen, fireEvent } from "@testing-library/react";
import App from "./App";

describe("App component", () => {
  it("renders the Vite + React header", () => {
    render(<App />);
    expect(screen.getByText(/Vite \+ React/i)).toBeInTheDocument();
  });

  it("increments the count when the button is clicked", async () => {
    render(<App />);
    // Initially, the button text should be "count is 0"
    const counterButton = screen.getByRole("button", { name: /count is 0/i });
    expect(counterButton).toBeInTheDocument();

    // Simulate a user click on the button
    fireEvent.click(counterButton);

    // After clicking, the button text should be "count is 1"
    expect(
      screen.getByRole("button", { name: /count is 1/i })
    ).toBeInTheDocument();
  });
});
