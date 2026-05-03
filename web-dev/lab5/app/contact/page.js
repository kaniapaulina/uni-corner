"use client";
import { motion } from "framer-motion";

export default function ContactPage() {
  return (
    <main className="pt-24 min-h-screen bg-white">
      <div className="max-w-7xl mx-auto px-8 py-16 grid lg:grid-cols-2 gap-20">
        
        {/* Left: Contact Info */}
        <motion.div initial={{ opacity: 0 }} animate={{ opacity: 1 }}>
          <h1 className="text-6xl font-black mb-10 tracking-tighter">BĄDŹMY W <br/><span className="text-[#A30B33]">KONTAKCIE</span>.</h1>
          
          <div className="space-y-12">
            <div>
              <h3 className="text-[#A30B33] font-mono font-bold text-sm uppercase mb-4 tracking-widest">Lokalizacja</h3>
              <p className="text-2xl font-medium text-[#111827]">ul. Gramatyka 10, 30-067 Kraków<br/>Budynek D-14</p>
            </div>

            <div className="grid sm:grid-cols-2 gap-8">
              <div>
                <h3 className="text-[#A30B33] font-mono font-bold text-sm uppercase mb-4 tracking-widest">Dziekanat</h3>
                <p className="text-lg">tel: +48 12 617 43 00</p>
                <p className="text-lg text-gray-500">wz@agh.edu.pl</p>
              </div>
              <div>
                <h3 className="text-[#A30B33] font-mono font-bold text-sm uppercase mb-4 tracking-widest">Rekrutacja</h3>
                <p className="text-lg">tel: +48 12 617 38 30</p>
                <p className="text-lg text-gray-500">rekrutacja-wz@agh.edu.pl</p>
              </div>
            </div>
          </div>
        </motion.div>

        {/* Right: Modern Form/Map Placeholder */}
        <div className="bg-[#111827] rounded-[2rem] p-10 text-white relative overflow-hidden shadow-2xl">
          <div className="absolute top-0 right-0 p-8 opacity-10">
             <svg width="200" height="200" fill="white" viewBox="0 0 24 24"><path d="M12 2C8.13 2 5 5.13 5 9c0 5.25 7 13 7 13s7-7.75 7-13c0-3.87-3.13-7-7-7z"/></svg>
          </div>
          <h3 className="text-2xl font-bold mb-8">Godziny otwarcia</h3>
          <ul className="space-y-4 border-l-2 border-[#A30B33] pl-6">
            <li className="flex justify-between"><span>Poniedziałek - Piątek</span> <span className="font-mono">08:00 - 16:00</span></li>
            <li className="flex justify-between text-gray-400"><span>Sobota (Studia Zaoczne)</span> <span className="font-mono">09:00 - 14:00</span></li>
          </ul>
          
          <div className="mt-12">
             <button className="w-full bg-[#A30B33] py-4 rounded-xl font-bold hover:bg-[#820929] transition-all">
                WIRTUALNY SPACER PO WYDZIALE
             </button>
          </div>
        </div>

      </div>
    </main>
  );
}