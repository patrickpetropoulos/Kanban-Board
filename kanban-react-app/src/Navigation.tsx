// Navigation.tsx
import React from "react";
import { Link } from "react-router-dom";

const Navigation: React.FC = () => {
  return (
    <nav className="bg-gray-800 p-4 flex justify-between">
      <ul className="flex">
        <li className="mr-6">
          <Link to="/" className="text-white hover:text-gray-300">
            Home
          </Link>
        </li>
        <li className="mr-6">
          <Link to="/about" className="text-white hover:text-gray-300">
            About
          </Link>
        </li>
        <li className="mr-6">
          <Link to="/contact" className="text-white hover:text-gray-300">
            Contact
          </Link>
        </li>
      </ul>
      <ul className="flex">
        <li>
          <Link to="/user" className="text-white hover:text-gray-300">
            User
          </Link>
        </li>
      </ul>
    </nav>
  );
};

export default Navigation;
