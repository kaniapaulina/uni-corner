"use client";
import { motion } from "framer-motion";

export default function AboutPage() {
  return (
    <main className="pt-24 min-h-screen bg-white">
      {/* Hero Subpage */}
      <section className="h-[60vh] bg-[#111827] flex items-center px-8 relative overflow-hidden">
        <div className="absolute right-0 top-0 w-1/3 h-full bg-[#A30B33] opacity-10 skew-x-12 transform translate-x-20" />
        <div className="max-w-4xl z-10">
          <motion.h1 
            initial={{ opacity: 0, x: -20 }}
            animate={{ opacity: 1, x: 0 }}
            className="text-5xl md:text-7xl font-black text-white mb-6"
          >
            TRADYCJA <br/><span className="text-[#A30B33]">INNOWACJI</span>.
          </motion.h1>
          <p className="text-gray-400 text-xl max-w-2xl">
            Od lat kształcimy liderów, którzy potrafią łączyć klasyczne zarządzanie z najnowszymi osiągnięciami technologicznymi AGH.
          </p>
        </div>
      </section>

      {/* Content Section */}
      <section className="py-20 px-8 max-w-7xl mx-auto grid md:grid-cols-2 gap-16">
        <div>
          <h2 className="text-3xl font-bold mb-6 border-b-2 border-[#A30B33] pb-2 inline-block">Misja i Wizja</h2>
          <p className="text-gray-600 leading-relaxed text-lg italic">
            "Naszą misją jest prowadzenie najwyższej jakości badań naukowych oraz kształcenie kadr menedżerskich przygotowanych do pracy w gospodarce opartej na wiedzy."
          </p>
        </div>
        <div className="bg-gray-50 p-8 rounded-2xl border border-gray-100">
          <h3 className="font-bold text-xl mb-4 text-[#111827]">Dlaczego WZ AGH?</h3>
          <ul className="space-y-4 text-gray-600">
            <li className="flex items-start gap-3">
              <span className="text-[#A30B33] font-bold">01.</span> Unikalne połączenie kompetencji twardych (inżynierskich) z miękkimi.
            </li>
            <li className="flex items-start gap-3">
              <span className="text-[#A30B33] font-bold">02.</span> Dostęp do najnowocześniejszych laboratoriów i oprogramowania klasy Enterprise.
            </li>
            <li className="flex items-start gap-3">
              <span className="text-[#A30B33] font-bold">03.</span> Silne relacje z sektorem IT i finansowym w Krakowie.
            </li>
          </ul>
        </div>
      </section>
    </main>
  );
}