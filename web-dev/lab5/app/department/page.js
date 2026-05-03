"use client";
import { motion } from "framer-motion";

<div className="grid grid-cols-2 md:grid-cols-4 gap-4 mb-20">
  {[
    { label: 'Publikacje (2023)', val: '450+' },
    { label: 'Projekty NCN/NCBiR', val: '28' },
    { label: 'Kadra Naukowa', val: '180' },
    { label: 'Patenty/Wdrożenia', val: '12' }
  ].map((stat, i) => (
    <div key={i} className="bg-white p-6 rounded-2xl border border-slate-100 shadow-sm text-center">
      <p className="text-3xl font-black text-[#111827]">{stat.val}</p>
      <p className="text-[10px] uppercase tracking-widest text-[#A30B33] font-bold mt-2">{stat.label}</p>
    </div>
  ))}
</div>

const departments = [
  { id: "KO", title: "Katedra Organizacji i Zarządzania", chief: "prof. dr hab. inż. Jan Kowalski", focus: "Teoria organizacji, Lean Management, Agile." },
  { id: "KE", title: "Katedra Ekonomii i Finansów", chief: "dr hab. Maria Nowak, prof. AGH", focus: "Analiza rynków kapitałowych, Fintech, Mikroekonomia." },
  { id: "KI", title: "Katedra Zastosowań Informatyki", chief: "prof. dr hab. Adam Smith", focus: "Business Intelligence, Systemy ERP, Cyberbezpieczeństwo." },
  // ... więcej katedr z www.zarz.agh.edu.pl
];

export default function DepartmentsPage() {
  return (
    <main className="pt-24 min-h-screen bg-[#F9FAFB]">
      <div className="px-8 py-12 max-w-7xl mx-auto">
        <header className="mb-16">
          <h1 className="text-4xl font-black text-[#111827] uppercase tracking-tight">
            Struktura <span className="text-[#A30B33]">Badawcza</span>
          </h1>
          <p className="text-gray-500 mt-2">Przegląd jednostek naukowo-dydaktycznych Wydziału Zarządzania.</p>
        </header>

        <div className="grid md:grid-cols-2 lg:grid-cols-3 gap-8">
          {departments.map((dept, idx) => (
            <motion.div 
              key={dept.id}
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ delay: idx * 0.1 }}
              className="bg-white p-8 rounded-xl shadow-sm hover:shadow-xl transition-all border-t-4 border-gray-100 hover:border-[#A30B33] group"
            >
              <div className="text-xs font-mono text-[#A30B33] mb-4 font-bold">{dept.id} RESEARCH_UNIT</div>
              <h3 className="text-xl font-bold mb-3 group-hover:text-[#A30B33] transition-colors">{dept.title}</h3>
              <p className="text-sm text-gray-400 mb-6">{dept.focus}</p>
              <div className="pt-4 border-t border-gray-50">
                <p className="text-xs uppercase text-gray-500 font-bold">Kierownik katedry:</p>
                <p className="text-sm font-medium">{dept.chief}</p>
              </div>
            </motion.div>
          ))}
        </div>
      </div>
    </main>
  );
}