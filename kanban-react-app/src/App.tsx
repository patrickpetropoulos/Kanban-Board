import "./App.css";

function App() {
  return (
    <div className="App">
      <div className="max-w-md mx-auto bg-blue-50 rounded-xl shadow-md overflow-hidden md:max-w-2xl p-5 m-5">
        <div className="md:flex">
          <div className="p-12">
            <div className="uppercase tracking-wide text-sm text-indigo-500 font-semibold">
              Card Title
            </div>
            <a
              href="#"
              className="block mt-1 text-lg leading-tight font-medium text-black hover:underline"
            >
              Some interesting topic
            </a>
            <p className="mt-2 text-gray-500">
              This space can be used to write a short description or snippet
              about the topic. Let's keep it simple and elegant with Tailwind
              CSS! with Varialble {process.env.REACT_APP_API_URL}
            </p>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
