import { Inter } from 'next/font/google';
import { GeistSans } from 'geist/font/sans';
import { GeistMono } from 'geist/font/mono';
import './globals.css';

// Konfiguracja fontu Inter z Google Fonts
const inter = Inter({ subsets: ['latin'] });

export const metadata = {
  title: 'Wydział Zarządzania AGH | Nowoczesne Zarządzanie i Data Science',
  description: 'Oficjalna strona Wydziału Zarządzania AGH stworzona w technologii Next.js',
  authors: [{ name: 'Twoje Imię' }],
  keywords: 'AGH, Wydział Zarządzania, Zarządzanie, Data Science, Kraków',
};

export default function RootLayout({ children }) {
  return (
    <html lang="pl" className="scroll-smooth">
      {/* Łączymy font Inter (główny) z Geist (do elementów technicznych/liczb) */}
      <body className={`${inter.className} ${GeistSans.variable} ${GeistMono.variable} antialiased bg-[#F9FAFB] text-slate-900`}>
        {children}
      </body>
    </html>
  );
}