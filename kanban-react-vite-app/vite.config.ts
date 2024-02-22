// vite.config.js
import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react-swc';

export default defineConfig({
  plugins: [react()],
  build: {
    // Specify the output directory here, relative to the project root
    outDir: '../Kanban.Server.WebApp/wwwroot/',
  },
  // If you serve your app from a subpath, you may need to set base
  base: './', // Adjust this as needed, e.g., '/myapp/'
});
