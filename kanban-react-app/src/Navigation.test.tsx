// Navigation.test.tsx
import React from "react";
import { render } from "@testing-library/react";
import { MemoryRouter } from "react-router-dom";
import Navigation from "./Navigation";

test("renders navigation links", () => {
  const { getByText } = render(
    <MemoryRouter>
      <Navigation />
    </MemoryRouter>
  );
  const homeLink = getByText(/home/i);
  const aboutLink = getByText(/about/i);
  const contactLink = getByText(/contact/i);
  const userLink = getByText(/user/i);
  const failedLink = getByText(/fail/i);

  expect(homeLink).toBeInTheDocument();
  expect(aboutLink).toBeInTheDocument();
  expect(contactLink).toBeInTheDocument();
  expect(userLink).toBeInTheDocument();
  expect(failedLink).toBeInTheDocument();
});
