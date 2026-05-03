/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      colors: {
        agh: {
          red: "#A30B33",      // Oficjalna czerwień AGH
          dark: "#111827",     // Głęboki granat (FinTech)
          silver: "#E5E7EB",   // Srebrne akcenty
        },
      },
      fontFamily: {
        sans: ['Inter', 'sans-serif'],
        technical: ['Geist Mono', 'monospace'], // Do danych i cyfr
      },
      backgroundImage: {
        'glass-gradient': 'linear-gradient(135deg, rgba(255,255,255,0.1), rgba(255,255,255,0.05))',
      }
    },
  },
  plugins: [],
}