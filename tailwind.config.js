/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Views/**/*.{cshtml,html}",
    "./wwwroot/**/*.{html,js}"
  ],
  theme: {
    extend: {},
  },
  plugins: [require("daisyui")],
  daisyui: {
    themes: ["dark", "light", "garden"],
  }
}

