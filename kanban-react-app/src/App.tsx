// App.tsx
import React from "react";
import { Route, Routes } from "react-router-dom";
import Navigation from "./Navigation";
import Home from "./pages/Home";
import About from "./pages/About";
import Contact from "./pages/Contact";
import Sidebar from "./components/Sidebar";
import { display } from "@mui/system";

const App: React.FC = () => {
  return (
    <div>
      <Navigation />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/contact" element={<Contact />} />
      </Routes>
    </div>
  );
};

export default App;
