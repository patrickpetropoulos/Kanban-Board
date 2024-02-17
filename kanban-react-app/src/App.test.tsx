// App.test.tsx
import React from "react";
import { fireEvent, render, screen } from "@testing-library/react";
import { MemoryRouter } from "react-router-dom";
import App from "./App";
import userEvent from "@testing-library/user-event";

test("renders navigation links and routes correctly", () => {
  render(
    <MemoryRouter initialEntries={["/"]}>
      <App />
    </MemoryRouter>
  );

  // Check if navigation links are present
  const homeLink = screen.getByRole("link", { name: /home/i });
  const aboutLink = screen.getByRole("link", { name: /about/i });
  const contactLink = screen.getByRole("link", { name: /contact/i });

  expect(homeLink).toBeInTheDocument();
  expect(aboutLink).toBeInTheDocument();
  expect(contactLink).toBeInTheDocument();

  // Check if clicking on navigation links navigates to the correct routes
  fireEvent.click(homeLink);
  expect(screen.getByText(/welcome to the home page/i)).toBeInTheDocument();

  fireEvent.click(aboutLink);
  expect(screen.getByText(/about us/i)).toBeInTheDocument();

  fireEvent.click(contactLink);
  expect(screen.getByText(/contact us/i)).toBeInTheDocument();
});
