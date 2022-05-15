module.exports = {
  mode: "jit",
  content: ["Views/**/*.cshtml", "Views/**/*.razor"],
  theme: {
    extend: {}
  },
  plugins: [
    require("@tailwindcss/typography"),
  ],
}
