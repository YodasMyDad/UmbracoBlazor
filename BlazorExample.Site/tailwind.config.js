module.exports = {
  mode: "jit",
  content: ["Views/**/*.cshtml", "Views/**/*.razor", "Components/**/*.razor"],
  theme: {
    extend: {}
  },
  plugins: [
    require("@tailwindcss/typography"),
  ],
}
