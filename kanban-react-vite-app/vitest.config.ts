import { defineConfig } from 'vitest/config';

export default defineConfig({
  test: {
    // Test configuration options
    setupFiles: ['./vitest-setup.ts'], // Adjust the path as necessary
    globals: true, // This enables global test functions like `test` and `expect`
    environment: 'jsdom', // This is typically what you want for testing React components
  },
});
