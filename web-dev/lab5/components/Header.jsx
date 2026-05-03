import Link from 'next/link';
import { motion } from 'framer-motion';

export const Header = () => (
  <header className="fixed top-0 w-full z-[100] bg-white/70 backdrop-blur-xl border-b border-gray-100">
    <div className="max-w-7xl mx-auto px-6 h-20 flex justify-between items-center">
      <Link href="/" className="flex items-center gap-3 group">
        <div className="w-10 h-10 bg-agh-red rounded shadow-lg group-hover:rotate-90 transition-transform duration-500" />
        <span className="font-bold text-xl tracking-tighter">WZ <span className="text-agh-red">AGH</span></span>
      </Link>
      
      <nav className="flex gap-8 items-center font-medium text-sm uppercase tracking-widest text-gray-500">
        <Link href="/about" className="hover:text-agh-red transition-colors">Wydział</Link>
        <Link href="/departments" className="hover:text-agh-red transition-colors">Katedry</Link>
        <Link href="/contact" className="hover:text-agh-red transition-colors">Kontakt</Link>
        <Link href="/contact" className="bg-agh-dark text-white px-5 py-2 rounded-full hover:bg-agh-red transition-all">Portal Studenta</Link>
      </nav>
    </div>
  </header>
);