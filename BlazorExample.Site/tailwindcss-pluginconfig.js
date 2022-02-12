module.exports = {
  prefix: "tw-",
  corePlugins: {
    preflight: false,
  },
  mode: "jit",
  content: ["App_Plugins/CustomPlugins/**/**/*.html", "../BlazorExample.Components/**/*.razor"],
  theme: {
    extend: {}
  },
  plugins: [
    
  ]
}