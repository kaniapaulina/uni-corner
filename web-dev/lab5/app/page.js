// "use client";
// import React, { useState, useEffect, useRef } from "react"; // Dodaj te!
// import { motion, useInView, animate } from "framer-motion";
// import Image from "next/image";

// // Kolory: Czerwień AGH: #A30B33, Granat FinTech: #111827
// const Header = () => {
//   const [isScrolled, setIsScrolled] = React.useState(false);

//   React.useEffect(() => {
//     const handleScroll = () => setIsScrolled(window.scrollY > 50);
//     window.addEventListener("scroll", handleScroll);
//     return () => window.removeEventListener("scroll", handleScroll);
//   }, []);

//   return (
//     <nav className={`fixed top-0 w-full z-[100] transition-all duration-500 px-8 ${
//       isScrolled ? "py-4 bg-white/70 backdrop-blur-xl border-b border-gray-200 shadow-sm" : "py-8 bg-transparent"
//     }`}>
//       <div className="max-w-7xl mx-auto flex justify-between items-center text-[#111827]">
//         <div className="flex items-center gap-4">
//           <div className="w-10 h-10 bg-[#A30B33] rounded shadow-lg flex items-center justify-center text-white font-bold italic">WZ</div>
//           <span className={`font-bold tracking-tight text-xl transition-colors ${!isScrolled && "text-white"}`}>
//             AGH <span className="text-[#A30B33]">ZARZĄDZANIE</span>
//           </span>
//         </div>
//         <div className={`hidden md:flex gap-10 font-bold text-[10px] uppercase tracking-[0.2em] ${!isScrolled ? "text-white/80" : "text-slate-600"}`}>
//           {["Start", "O Wydziale", "Kierunki", "Katedry", "Kontakt"].map((item) => (
//             <a key={item} href={`#${item.toLowerCase().replace(' ', '')}`} className="hover:text-[#A30B33] transition-colors">
//               {item}
//             </a>
//           ))}
//         </div>
//       </div>
//     </nav>
//   );
// };


// const Counter = ({ from, to, label }) => {
//   const [count, setCount] = useState(from);
//   const nodeRef = useRef(null);
//   const inView = useInView(nodeRef, { once: true });

//   useEffect(() => {
//     if (inView) {
//       const controls = animate(from, to, {
//         duration: 2,
//         onUpdate: (value) => setCount(Math.floor(value)),
//       });
//       return () => controls.stop();
//     }
//   }, [inView, from, to]);

//   return (
//     <div ref={nodeRef} className="flex flex-col">
//       <span className="text-5xl font-black text-[#A30B33] tabular-nums tracking-tighter">
//         {count}+
//       </span>
//       <span className="text-[10px] uppercase tracking-[0.3em] font-bold text-slate-400 mt-2">
//         {label}
//       </span>
//     </div>
//   );
// };

// // Użycie w sekcji:
// // <Counter from={0} to={50} label="Lat tradycji" />
// // <Counter from={0} to={300} label="Partnerów biznesowych" />

// const MajorSection = () => {
//   const [activeImg, setActiveImg] = useState("https://images.unsplash.com/photo-1460925895917-afdab827c52f?q=80&w=2026&auto=format&fit=crop");
  
//   const majors = [
//     { name: "Zarządzanie", img: "https://images.unsplash.com/photo-1460925895917-afdab827c52f?q=80&w=2026&auto=format&fit=crop" },
//     { name: "Logistyka", img: "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?q=80&w=2070&auto=format&fit=crop" },
//     { name: "Informatyka Społeczna", img: "https://images.unsplash.com/photo-1550751827-4bd374c3f58b?q=80&w=2070&auto=format&fit=crop" },
//     { name: "Kulturoznawstwo", img: "https://images.unsplash.com/photo-1491843351663-7c116e8148c2?q=80&w=2070&auto=format&fit=crop" }
//   ];

//   return (
//     <section id="kierunki" className="h-screen relative flex items-center bg-[#111827] overflow-hidden">
//       {/* Dynamiczne Tło */}
//       <motion.div 
//         key={activeImg}
//         initial={{ opacity: 0 }}
//         animate={{ opacity: 0.2 }}
//         transition={{ duration: 1 }}
//         className="absolute inset-0 bg-cover bg-center"
//         style={{ backgroundImage: `url(${activeImg})` }}
//       />
      
//       <div className="relative z-10 w-full px-12 md:px-24">
//         <h2 className="text-white text-xs font-mono tracking-[0.5em] uppercase mb-12">// Kierunki Kształcenia</h2>
//         <div className="flex flex-col gap-4">
//           {majors.map((m) => (
//             <motion.h3
//               key={m.name}
//               onMouseEnter={() => setActiveImg(m.img)}
//               whileHover={{ x: 30 }}
//               className="text-5xl md:text-7xl font-black text-white/30 hover:text-white cursor-pointer transition-colors duration-300"
//             >
//               {m.name}.
//             </motion.h3>
//           ))}
//         </div>
//       </div>
//     </section>
//   );
// };


// const BentoGrid = () => (
//   <section className="py-24 bg-white px-8">
//     <div className="max-w-7xl mx-auto">
//       <h2 className="text-4xl font-black mb-16 italic tracking-tighter uppercase">Wydział <span className="text-[#A30B33]">Żyje</span></h2>
//       <div className="grid grid-cols-1 md:grid-cols-4 grid-rows-2 gap-4 h-[800px] md:h-[600px]">
        
//         {/* Duży kafel - Koło IT */}
//         <div className="md:col-span-2 md:row-span-2 bg-[#A30B33] rounded-3xl p-10 text-white flex flex-col justify-end relative overflow-hidden group">
//           <div className="absolute top-0 right-0 p-8 opacity-20 text-8xl font-black">IT</div>
//           <h3 className="text-3xl font-black mb-4 uppercase">Koło Naukowe IT Zarządzanie</h3>
//           <p className="text-white/70">Największa organizacja studencka skupiająca pasjonatów Data Science i programowania.</p>
//         </div>

//         {/* Mały kafel - Sukces */}
//         <div className="md:col-span-2 bg-slate-100 rounded-3xl p-8 flex items-center gap-6 group hover:bg-slate-200 transition-colors">
//           <div className="w-20 h-20 bg-white rounded-2xl shadow-sm flex-shrink-0" />
//           <div>
//             <span className="text-[10px] font-black text-[#A30B33] uppercase tracking-widest">Sukces</span>
//             <h4 className="font-bold text-lg leading-tight">Nasze studentki na podium Hackathonu FinTech!</h4>
//           </div>
//         </div>

//         {/* Kafel - Konferencja */}
//         <div className="bg-[#111827] rounded-3xl p-8 text-white flex flex-col justify-between">
//            <span className="text-[#A30B33] font-mono text-xs font-bold uppercase tracking-widest">12.05.2026</span>
//            <h4 className="font-bold">Konferencja: Przyszłość AI w Zarządzaniu</h4>
//         </div>

//         {/* Kafel - Social Media Style */}
//         <div className="bg-slate-50 border border-slate-100 rounded-3xl p-8 flex flex-col justify-center items-center text-center">
//            <p className="font-black text-4xl tracking-tighter italic">20+</p>
//            <p className="text-[10px] text-slate-400 uppercase font-bold tracking-widest">Kół Naukowych</p>
//         </div>

//       </div>
//     </div>
//   </section>
// );

// export default function Home() {
//   return (
//     <main className="relative">
//       {/* --- MENU NAWIGACYJNE --- */}
//       {/* <nav className="fixed top-0 w-full z-50 bg-white/80 backdrop-blur-md border-b border-gray-200 py-4 px-8 flex justify-between items-center">
//         <div className="flex items-center gap-4">
//           <div className="w-12 h-12 bg-[#A30B33] rounded-lg flex items-center justify-center text-white font-bold italic">WZ</div>
//           <span className="font-bold tracking-tight text-xl">AGH <span className="text-[#A30B33]">ZARZĄDZANIE</span></span>
//         </div>
//         <div className="hidden md:flex gap-8 font-medium text-sm uppercase tracking-wider text-slate-600">
//           <a href="#hero" className="hover:text-[#A30B33] transition-colors">Start</a>
//           <a href="#info" className="hover:text-[#A30B33] transition-colors">O Wydziale</a>
//           <a href="#katedry" className="hover:text-[#A30B33] transition-colors">Katedry</a>
//           <a href="#kontakt" className="hover:text-[#A30B33] transition-colors">Kontakt</a>
//         </div>
//       </nav> */}
//       <Header />

//       {/* --- SEKACJA 1: HERO (STRONA GŁÓWNA) --- */}
//       <section id="hero" className="h-screen flex items-center justify-center bg-[#111827] text-white relative overflow-hidden px-6">
//         {/* Tło z efektem paralaksy/gradientu */}
//         <div className="absolute inset-0 z-0">
//           <div className="absolute inset-0 bg-gradient-to-b from-[#111827]/80 via-[#111827]/50 to-[#111827] z-10" />
//           <Image 
//             src="/hero-campus.png" // Zakładając, że plik jest w folderze public
//             alt="Kampus AGH"
//             fill
//             className="object-cover opacity-40"
//             priority
//           />
//         </div>
        
//         <motion.div 
//           initial={{ opacity: 0, y: 30 }}
//           animate={{ opacity: 1, y: 0 }}
//           transition={{ duration: 0.8 }}
//           className="z-20 max-w-6xl text-center md:text-left">
//           <motion.div 
//             initial={{ opacity: 0, scale: 0.9 }}
//             animate={{ opacity: 1, scale: 1 }}
//             className="inline-block px-4 py-1 border border-[#A30B33] text-[#A30B33] font-mono text-xs mb-8 rounded-full"
//           >WYDZIAŁ ZARZĄDZANIA AGH // EST. 1974
//           </motion.div>
          
//           <h1 className="text-5xl md:text-8xl font-black leading-tight mb-8 tracking-tighter">
//             ZARZĄDZANIE <br />
//             <span className="text-transparent bg-clip-text bg-gradient-to-r from-[#A30B33] to-[#ff4d7d]">
//               NOWEJ GENERACJI
//             </span>
//           </h1>
          
//           <p className="text-gray-400 text-lg md:text-xl max-w-2xl mb-12 font-light leading-relaxed">
//             Łączymy analityczne podejście **Data Science** z wizjonerskim przywództwem. 
//             Kształcimy ekspertów gotowych na wyzwania gospodarki 4.0.
//           </p>
          
//           <div className="flex flex-col md:flex-row gap-6 justify-center md:justify-start">
//             <button className="bg-[#A30B33] hover:bg-[#820929] px-10 py-4 text-sm font-bold rounded-xl transition-all hover:shadow-[0_0_30px_rgba(163,11,51,0.4)]">
//               REKRUTACJA 2024
//             </button>
//             <button className="border border-white/20 hover:bg-white/10 px-10 py-4 text-sm font-bold rounded-xl transition-all backdrop-blur-sm">
//               OFERTA EDUKACYJNA
//             </button>
//           </div>
//         </motion.div>

//         {/* Subtelny scroll-indicator */}
//         <div className="absolute bottom-10 left-1/2 -translate-x-1/2 animate-bounce opacity-30">
//           <div className="w-px h-12 bg-white" />
//         </div>
//     </section>

//       {/* --- SEKCJA 2: O WYDZIALE --- */}
//       <section id="info" className="min-h-screen flex flex-col justify-center bg-white py-24 px-8 md:px-24">
//       <div className="max-w-7xl mx-auto">
//         <div className="grid md:grid-cols-2 gap-16 items-center mb-24">
//           <motion.div 
//             whileInView={{ opacity: 1, x: 0 }}
//             initial={{ opacity: 0, x: -50 }}
//             viewport={{ once: true }}
//           >
//             <span className="text-[#A30B33] font-bold tracking-widest text-sm uppercase mb-4 block">O nas</span>
//             <h2 className="text-5xl font-black text-[#111827] mb-8 tracking-tight">
//               Gdzie technologia <br /> spotyka biznes.
//             </h2>
//             <p className="text-xl text-slate-600 leading-relaxed mb-8 font-light">
//               Jesteśmy jednym z najdynamiczniej rozwijających się wydziałów AGH. 
//               Naszą misją jest dostarczanie wiedzy, która pozwala zarządzać w świecie zdominowanym przez algorytmy i dane.
//             </p>
            
//             <div className="flex gap-12">
//               <div>
//                 <span className="block text-4xl font-black text-[#A30B33]">#1</span>
//                 <span className="text-xs text-slate-400 uppercase font-bold">W rankingach innowacyjności</span>
//               </div>
//               <div className="border-l border-slate-200 pl-12">
//                 <span className="block text-4xl font-black text-[#A30B33]">15k+</span>
//                 <span className="text-xs text-slate-400 uppercase font-bold">Absolwentów na rynku</span>
//               </div>
//               <Counter from={0} to={50} label="Lat tradycji" />
//               <Counter from={0} to={300} label="Partnerów biznesowych" />
//             </div>
//           </motion.div>

//           <motion.div 
//             whileInView={{ opacity: 1, scale: 1 }}
//             initial={{ opacity: 0, scale: 0.9 }}
//             viewport={{ once: true }}
//             className="relative h-[500px] rounded-[2rem] overflow-hidden shadow-2xl"
//           >
//             <Image 
//               src="/hero-campus.png" // Pamiętaj o folderze public!
//               alt="Wnętrze AGH"
//               fill
//               className="object-cover"
//             />
//             <div className="absolute inset-0 bg-gradient-to-t from-[#A30B33]/40 to-transparent" />
//           </motion.div>
//         </div>

//         {/* Dodatkowe karty korzyści (Fintech Style) */}
//         <div className="grid md:grid-cols-3 gap-8">
//           {[
//             { title: "Big Data & AI", desc: "Zarządzanie oparte na twardych danych i analityce predykcyjnej." },
//             { title: "Przemysł 4.0", desc: "Przygotowanie do pracy w zrobotyzowanych środowiskach produkcyjnych." },
//             { title: "FinTech", desc: "Nowoczesne finanse w dobie blockchain i cyfrowej transformacji." }
//           ].map((item, index) => (
//             <motion.div 
//               key={index}
//               initial={{ opacity: 0, y: 20 }}
//               whileInView={{ opacity: 1, y: 0 }}
//               transition={{ delay: index * 0.2 }}
//               viewport={{ once: true }}
//               className="p-10 bg-slate-50 rounded-2xl border border-slate-100 hover:bg-white hover:shadow-xl transition-all group"
//             >
//               <div className="w-12 h-12 bg-white rounded-xl shadow-sm flex items-center justify-center mb-6 group-hover:bg-[#A30B33] transition-colors">
//                 <div className="w-2 h-2 bg-[#A30B33] rounded-full group-hover:bg-white" />
//               </div>
//               <h3 className="text-xl font-bold mb-4 text-[#111827]">{item.title}</h3>
//               <p className="text-slate-500 font-light leading-relaxed">{item.desc}</p>
//             </motion.div>
//           ))}
//         </div>
//       </div>
//     </section>

//     <MajorSection />

//       {/* --- SEKCJA 3: KATEDRY --- */}
//       {/* --- SEKCJA 3: KATEDRY (STRONA GŁÓWNA) --- */}
//       <section id="katedry" className="min-h-screen bg-[#F9FAFB] py-24 px-8 flex flex-col justify-center">
//         <div className="max-w-7xl mx-auto w-full">
//           <div className="flex flex-col md:flex-row justify-between items-end mb-16 gap-6">
//             <div className="max-w-2xl">
//               <h2 className="text-5xl font-black mb-6 uppercase tracking-tighter italic">
//                 Jednostki <span className="text-[#A30B33]">Badawcze</span>
//               </h2>
//               <p className="text-slate-500 text-lg">
//                 Nasi eksperci prowadzą badania w kluczowych obszarach nowoczesnej gospodarki – od optymalizacji linii produkcyjnych po algorytmy sztucznej inteligencji w finansach.
//               </p>
//             </div>
//             <a href="/departments" className="text-[#A30B33] font-bold border-b-2 border-[#A30B33] pb-1 hover:text-[#111827] hover:border-[#111827] transition-all">
//               Zobacz pełną strukturę →
//             </a>
//           </div>

//           <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
//             {[
//               { t: 'Katedra Zastosowań Informatyki', d: 'Lider w obszarze systemów ERP, Big Data oraz sztucznej inteligencji wspomagającej decyzje biznesowe.', code: 'KZI' },
//               { t: 'Katedra Inżynierii Zarządzania', d: 'Specjalizacja w przemyśle 4.0, logistyce produkcji oraz inżynierii jakości.', code: 'KIZ' },
//               { t: 'Katedra Ekonomii i Finansów', d: 'Badania nad rynkami kapitałowymi, FinTech oraz ekonomicznymi aspektami transformacji energetycznej.', code: 'KEF' },
//               { t: 'Katedra Zarządzania Operacyjnego', d: 'Modelowanie procesów biznesowych i optymalizacja łańcuchów dostaw.', code: 'KZO' },
//               { t: 'Katedra Kapitału Ludzkiego', d: 'Nowoczesne HR, psychologia w zarządzaniu oraz rozwój kompetencji przyszłości.', code: 'KKL' },
//               { t: 'Katedra Zarządzania Przedsiębiorstwem', d: 'Strategie rozwoju, modele biznesowe oraz zarządzanie innowacjami i projektami.', code: 'KZP' }
//             ].map((cat, i) => (
//               <motion.div 
//                 key={i}
//                 whileHover={{ y: -10, shadow: "0 20px 25px -5px rgb(0 0 0 / 0.1)" }}
//                 className="bg-white p-10 rounded-2xl border border-slate-100 shadow-sm transition-all cursor-pointer group relative overflow-hidden"
//               >
//                 <div className="absolute top-0 right-0 p-6 text-slate-50 font-black text-6xl group-hover:text-slate-100 transition-colors z-0">
//                   {cat.code}
//                 </div>
//                 <div className="relative z-10">
//                   <div className="w-12 h-1 bg-[#A30B33] mb-6 group-hover:w-full transition-all duration-500" />
//                   <h3 className="font-bold text-xl mb-4 text-[#111827] group-hover:text-[#A30B33] transition-colors">{cat.t}</h3>
//                   <p className="text-slate-500 text-sm leading-relaxed">{cat.d}</p>
//                 </div>
//               </motion.div>
//             ))}
//           </div>
//         </div>
//       </section>

//       <BentoGrid />

//       {/* --- SEKCJA 4: KONTAKT (STRONA GŁÓWNA - PRAWA KOLUMNA) --- */}
//       {/* --- SEKCJA 4: KONTAKT --- */}
//       <section id="kontakt" className="min-h-screen bg-white flex items-center justify-center py-24 px-6 md:px-12">
//         <div className="max-w-7xl w-full mx-auto">
//           <div className="grid lg:grid-cols-2 gap-12 lg:gap-24 items-stretch">
            
//             {/* LEWA KOLUMNA: Informacje tekstowe */}
//             <motion.div 
//               initial={{ opacity: 0, x: -30 }}
//               whileInView={{ opacity: 1, x: 0 }}
//               viewport={{ once: true }}
//               className="flex flex-col justify-center space-y-12"
//             >
//               <div>
//                 <h2 className="text-6xl font-black text-[#111827] mb-6 tracking-tighter uppercase">
//                   Skontaktuj <br /> się z <span className="text-[#A30B33]">nami</span>
//                 </h2>
//                 <div className="w-20 h-1.5 bg-[#A30B33]" />
//               </div>

//               <div className="space-y-8">
//                 <div className="group cursor-pointer">
//                   <p className="text-[#A30B33] font-mono text-xs uppercase tracking-[0.3em] mb-2 font-bold">// Lokalizacja</p>
//                   <p className="text-2xl font-semibold text-[#111827] group-hover:text-[#A30B33] transition-colors">
//                     ul. Gramatyka 10, 30-067 Kraków
//                   </p>
//                   <p className="text-slate-500">Budynek D-14, Wydział Zarządzania AGH</p>
//                 </div>

//                 <div className="grid sm:grid-cols-2 gap-8">
//                   <div>
//                     <p className="text-[#A30B33] font-mono text-xs uppercase tracking-[0.3em] mb-2 font-bold">// Sekretariat</p>
//                     <p className="text-xl font-bold">+48 12 617 38 30</p>
//                     <p className="text-slate-500">wz@agh.edu.pl</p>
//                   </div>
//                   <div>
//                     <p className="text-[#A30B33] font-mono text-xs uppercase tracking-[0.3em] mb-2 font-bold">// Rekrutacja</p>
//                     <p className="text-xl font-bold">+48 12 617 43 00</p>
//                     <p className="text-slate-500">rekrutacja-wz@agh.edu.pl</p>
//                   </div>
//                 </div>
//               </div>
//             </motion.div>

//             {/* PRAWA KOLUMNA: Ciemna karta władz (teraz zbalansowana) */}
//             <motion.div 
//               initial={{ opacity: 0, y: 30 }}
//               whileInView={{ opacity: 1, y: 0 }}
//               viewport={{ once: true }}
//               className="bg-[#111827] rounded-[3rem] p-8 md:p-14 text-white relative overflow-hidden shadow-[0_30px_60px_-15px_rgba(0,0,0,0.3)] flex flex-col justify-between"
//             >
//               <div className="absolute top-0 right-0 p-12 opacity-5">
//                 <svg width="200" height="200" viewBox="0 0 24 24" fill="white"><path d="M12 2L2 7l10 5 10-5-10-5zM2 17l10 5 10-5M2 12l10 5 10-5"/></svg>
//               </div>

//               <div>
//                 <div className="flex items-center gap-4 mb-10">
//                   <div className="h-px w-8 bg-[#A30B33]" />
//                   <h3 className="text-2xl font-bold uppercase tracking-widest italic text-slate-200">
//                     Władze <span className="text-[#A30B33]">Wydziału</span>
//                   </h3>
//                 </div>
                
//                 <div className="space-y-10">
//                   <div className="flex items-center gap-6">
//                     <div className="relative">
//                       <div className="w-20 h-20 bg-gradient-to-br from-[#A30B33] to-[#7a0826] rounded-2xl rotate-3 absolute inset-0" />
//                       <div className="w-20 h-20 bg-slate-800 rounded-2xl relative z-10 border border-white/10 flex items-center justify-center text-2xl font-black">
//                         DZ
//                       </div>
//                     </div>
//                     <div>
//                       <p className="text-[#A30B33] font-mono text-[10px] uppercase tracking-[0.4em] font-bold mb-1">Dziekan WZ AGH</p>
//                       <p className="text-xl font-bold tracking-tight">prof. dr hab. inż. Marek Lutyński</p>
//                     </div>
//                   </div>

//                   <div className="p-8 bg-white/5 rounded-[2rem] border border-white/10 backdrop-blur-sm">
//                     <h4 className="font-bold mb-3 text-xs uppercase tracking-widest text-[#A30B33]">Godziny Przyjęć</h4>
//                     <p className="text-slate-300 text-lg">Pokój 114, I piętro</p>
//                     <div className="flex justify-between items-end mt-4">
//                       <p className="text-sm text-slate-400 font-mono">PONIEDZIAŁEK — PIĄTEK</p>
//                       <p className="text-xl font-bold text-white tracking-tighter font-mono">10:00 — 13:00</p>
//                     </div>
//                   </div>
//                 </div>
//               </div>

//               <div className="mt-16">
//                 <button className="group w-full bg-[#A30B33] hover:bg-white hover:text-[#111827] py-5 rounded-2xl font-black transition-all duration-500 flex items-center justify-center gap-4">
//                   NAPISZ DO NAS
//                   <svg className="group-hover:translate-x-2 transition-transform" width="24" height="24" fill="none" stroke="currentColor" strokeWidth="3" viewBox="0 0 24 24"><path d="M5 12h14M12 5l7 7-7 7"/></svg>
//                 </button>
//               </div>
//             </motion.div>

//           </div>
//         </div>
//       </section>

//       {/* --- STOPKA (FOOTER) --- */}
//       <footer className="bg-[#111827] text-white pt-20 pb-10 px-8 border-t border-white/5">
//         <div className="max-w-7xl mx-auto">
//           <div className="grid md:grid-cols-4 gap-12 mb-20 text-sm">
//             <div className="col-span-1 md:col-span-2">
//               <div className="flex items-center gap-3 mb-6 font-black text-2xl italic tracking-tighter">
//                 <div className="w-8 h-8 bg-[#A30B33] rounded" />
//                 AGH <span className="text-[#A30B33]">WZ</span>
//               </div>
//               <p className="text-slate-400 max-w-sm leading-relaxed font-light">
//                 Wydział Zarządzania AGH to centrum kompetencji przyszłości, gdzie dane stają się decyzjami, a innowacja — standardem.
//               </p>
//             </div>
//             <div>
//               <h4 className="font-bold text-white mb-6 uppercase tracking-widest text-xs">Nawigacja</h4>
//               <ul className="space-y-4 text-slate-400 font-medium">
//                 <li><a href="#hero" className="hover:text-[#A30B33] transition-colors">Start</a></li>
//                 <li><a href="#info" className="hover:text-[#A30B33] transition-colors">O Wydziale</a></li>
//                 <li><a href="#katedry" className="hover:text-[#A30B33] transition-colors">Struktura</a></li>
//                 <li><a href="#kontakt" className="hover:text-[#A30B33] transition-colors">Kontakt</a></li>
//               </ul>
//             </div>
//             <div>
//               <h4 className="font-bold text-white mb-6 uppercase tracking-widest text-xs">Standardy</h4>
//               <ul className="space-y-4 text-slate-500 font-mono text-[10px]">
//                 <li className="flex items-center gap-2 italic"><span className="w-1 h-1 bg-[#A30B33] rounded-full" /> W3C VALID HTML5</li>
//                 <li className="flex items-center gap-2 italic"><span className="w-1 h-1 bg-[#A30B33] rounded-full" /> WCAG 2.1 COMPLIANT</li>
//                 <li className="flex items-center gap-2 italic"><span className="w-1 h-1 bg-[#A30B33] rounded-full" /> NEXT.JS REACT 19</li>
//               </ul>
//             </div>
//           </div>
          
//           <div className="pt-8 border-t border-white/5 flex flex-col md:flex-row justify-between items-center gap-4 text-[11px] font-mono text-slate-600 uppercase tracking-[0.2em]">
//             <p>© 2026 Wydział Zarządzania AGH. Wszystkie prawa zastrzeżone.</p>
//             <p>Designed for excellence in Data Science.</p>
//           </div>
//         </div>
//       </footer>
//     </main>
//   );
// }

"use client";
import React, { useState, useEffect, useRef } from "react";
import { motion, useInView, animate } from "framer-motion";
import Image from "next/image";

// --- KOMPONENTY POMOCNICZE ---

const Header = () => {
  const [isScrolled, setIsScrolled] = useState(false);

  useEffect(() => {
    const handleScroll = () => setIsScrolled(window.scrollY > 50);
    window.addEventListener("scroll", handleScroll);
    return () => window.removeEventListener("scroll", handleScroll);
  }, []);

  return (
    <nav className={`fixed top-0 w-full z-[100] transition-all duration-500 px-8 ${
      isScrolled ? "py-4 bg-white/80 backdrop-blur-xl border-b border-gray-200 shadow-sm" : "py-8 bg-transparent"
    }`}>
      <div className="max-w-7xl mx-auto flex justify-between items-center">
        <div className="flex items-center gap-4">
          <div className="w-10 h-10 bg-[#A30B33] rounded shadow-lg flex items-center justify-center text-white font-bold italic">WZ</div>
          <span className={`font-bold tracking-tight text-xl transition-colors ${!isScrolled ? "text-white" : "text-[#111827]"}`}>
            AGH <span className="text-[#A30B33]">ZARZĄDZANIE</span>
          </span>
        </div>
        <div className={`hidden md:flex gap-10 font-bold text-[10px] uppercase tracking-[0.2em] ${!isScrolled ? "text-white/80" : "text-slate-600"}`}>
          {["Start", "O Wydziale", "Kierunki", "Katedry", "Kontakt"].map((item) => (
            <a key={item} href={`#${item.toLowerCase().replace(/\s/g, '')}`} className="hover:text-[#A30B33] transition-colors uppercase">
              {item}
            </a>
          ))}
        </div>
      </div>
    </nav>
  );
};

const Counter = ({ from, to, label }) => {
  const [count, setCount] = useState(from);
  const nodeRef = useRef(null);
  const inView = useInView(nodeRef, { once: true });

  useEffect(() => {
    if (inView) {
      const controls = animate(from, to, {
        duration: 2,
        onUpdate: (value) => setCount(Math.floor(value)),
      });
      return () => controls.stop();
    }
  }, [inView, from, to]);

  return (
    <div ref={nodeRef} className="flex flex-col">
      <span className="text-5xl font-black text-[#A30B33] tabular-nums tracking-tighter">
        {count}+
      </span>
      <span className="text-[10px] uppercase tracking-[0.3em] font-bold text-slate-400 mt-2">
        {label}
      </span>
    </div>
  );
};

const MajorSection = () => {
  const [activeImg, setActiveImg] = useState("https://images.unsplash.com/photo-1460925895917-afdab827c52f?q=80&w=2026");
  
  const majors = [
    { 
        name: "Zarządzanie", 
        desc: "Kształcimy menedżerów potrafiących zarządzać kapitałem ludzkim, finansami i marketingiem w dobie gospodarki cyfrowej.",
        img: "https://images.unsplash.com/photo-1454165833767-027ffea9e778?q=80&w=2070" 
    },
    { 
        name: "Informatyka i Ekonometria", 
        desc: "Analiza danych, modelowanie procesów ekonomicznych oraz wdrażanie zaawansowanych systemów IT w biznesie.",
        img: "https://images.unsplash.com/photo-1551288049-bbbda5366392?q=80&w=2070" 
    },
    { 
        name: "Inżynieria Zarządzania", 
        desc: "Unikalne połączenie wiedzy inżynierskiej z umiejętnościami menedżerskimi. Optymalizacja produkcji i logistyka 4.0.",
        img: "https://images.unsplash.com/photo-1581091226825-a6a2a5aee158?q=80&w=2070" 
    }
  ];

  return (
    <section id="kierunki" className="h-screen relative flex items-center bg-[#111827] overflow-hidden">
      <motion.div 
        key={activeImg}
        initial={{ opacity: 0 }}
        animate={{ opacity: 0.2 }}
        transition={{ duration: 1 }}
        className="absolute inset-0 bg-cover bg-center"
        style={{ backgroundImage: `url(${activeImg})` }}
      />
      
      <div className="relative z-10 w-full px-12 md:px-24 grid md:grid-cols-2 gap-12 items-center">
        <div>
            <h2 className="text-[#A30B33] text-xs font-mono tracking-[0.5em] uppercase mb-12 font-bold">// Oferta Edukacyjna</h2>
            <div className="flex flex-col gap-8">
            {majors.map((m) => (
                <div key={m.name} onMouseEnter={() => setActiveImg(m.img)} className="group cursor-pointer">
                    <motion.h3
                        whileHover={{ x: 20 }}
                        className="text-4xl md:text-6xl font-black text-white/40 group-hover:text-white transition-colors duration-300"
                    >
                        {m.name}
                    </motion.h3>
                    <p className="text-slate-500 max-w-sm mt-2 opacity-0 group-hover:opacity-100 transition-opacity duration-500">
                        {m.desc}
                    </p>
                </div>
            ))}
            </div>
        </div>
      </div>
    </section>
  );
};

const BentoGrid = () => (
  <section id="zycie" className="py-24 bg-white px-8">
    <div className="max-w-7xl mx-auto">
      <h2 className="text-4xl font-black mb-16 italic tracking-tighter uppercase">Wydział <span className="text-[#A30B33]">Tętniący Życiem</span></h2>
      <div className="grid grid-cols-1 md:grid-cols-4 grid-rows-2 gap-4 h-auto md:h-[600px]">
        <div className="md:col-span-2 md:row-span-2 bg-[#A30B33] rounded-3xl p-10 text-white flex flex-col justify-end relative overflow-hidden group">
          <div className="absolute top-0 right-0 p-8 opacity-20 text-8xl font-black uppercase">Data</div>
          <h3 className="text-3xl font-black mb-4 uppercase leading-tight">Koło Naukowe IT Zarządzanie</h3>
          <p className="text-white/70">Wspieramy studentów w nauce programowania, analizie Big Data i tworzeniu nowoczesnych rozwiązań dla biznesu.</p>
        </div>
        <div className="md:col-span-2 bg-slate-100 rounded-3xl p-8 flex items-center gap-6 hover:bg-slate-200 transition-colors">
          <div className="w-20 h-20 bg-white rounded-2xl flex-shrink-0 flex items-center justify-center text-3xl">🏆</div>
          <div>
            <span className="text-[10px] font-black text-[#A30B33] uppercase tracking-widest">Wyróżnienie</span>
            <h4 className="font-bold text-lg leading-tight">WZ AGH z prestiżową akredytacją jakości kształcenia.</h4>
          </div>
        </div>
        <div className="bg-[#111827] rounded-3xl p-8 text-white flex flex-col justify-between border-b-4 border-[#A30B33]">
           <span className="text-[#A30B33] font-mono text-xs font-bold uppercase tracking-widest">Kariera</span>
           <h4 className="font-bold">90% naszych absolwentów znajduje pracę w zawodzie w 3 miesiące.</h4>
        </div>
        <div className="bg-slate-50 border border-slate-200 rounded-3xl p-8 flex flex-col justify-center items-center text-center group hover:border-[#A30B33] transition-colors">
           <p className="font-black text-4xl tracking-tighter italic group-hover:scale-110 transition-transform">1974</p>
           <p className="text-[10px] text-slate-400 uppercase font-bold tracking-widest">Rok powstania wydziału</p>
        </div>
      </div>
    </div>
  </section>
);

// --- GŁÓWNA STRONA ---

export default function Home() {
  return (
    <main className="relative selection:bg-[#A30B33] selection:text-white">
      <Header />

      {/* SEKCJA 1: HERO */}
      <section id="start" className="h-screen flex items-center justify-center bg-[#111827] text-white relative overflow-hidden px-6">
        <div className="absolute inset-0 z-0">
          <div className="absolute inset-0 bg-gradient-to-b from-[#111827]/80 via-[#111827]/50 to-[#111827] z-10" />
          <Image 
            src="/hero-campus.png" 
            alt="Kampus AGH"
            fill
            className="object-cover opacity-40"
            priority
          />
        </div>
        
        <motion.div 
          initial={{ opacity: 0, y: 30 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.8 }}
          className="z-20 max-w-6xl text-center md:text-left">
          <motion.div 
            initial={{ opacity: 0, scale: 0.9 }}
            animate={{ opacity: 1, scale: 1 }}
            className="inline-block px-4 py-1 border border-[#A30B33] text-[#A30B33] font-mono text-[10px] mb-8 rounded-full uppercase tracking-widest font-bold"
          >
            Wydział Zarządzania AGH // Akademia Przyszłości
          </motion.div>
          
          <h1 className="text-5xl md:text-8xl font-black leading-tight mb-8 tracking-tighter">
              ZARZĄDZANIE <br />
             <span className="text-transparent bg-clip-text bg-gradient-to-r from-[#A30B33] to-[#ff4d7d]">
               NOWEJ GENERACJI
             </span>
           </h1>
          
          <p className="text-slate-400 text-lg md:text-xl max-w-2xl mb-12 font-light leading-relaxed">
            Jednostka naukowa kategorii <b>A</b>. Kształcimy liderów nowoczesnego biznesu, 
            łącząc twarde kompetencje inżynierskie z wizjonerskim menedżmentem.
          </p>
          
          <div className="flex flex-col md:flex-row gap-6">
            <button className="bg-[#A30B33] hover:bg-[#820929] px-10 py-4 text-xs font-bold rounded-xl transition-all uppercase tracking-widest">
              Zrekrutuj się
            </button>
            <button className="border border-white/20 hover:bg-white/10 px-10 py-4 text-xs font-bold rounded-xl transition-all backdrop-blur-sm uppercase tracking-widest">
              Dla studenta
            </button>
          </div>
        </motion.div>
        <div className="absolute bottom-10 left-1/2 -translate-x-1/2 animate-bounce opacity-20">
          <div className="w-px h-16 bg-white" />
        </div>
    </section>

      {/* SEKCJA 2: O WYDZIALE */}
      <section id="owydziale" className="min-h-screen flex flex-col justify-center bg-white py-24 px-8 md:px-24">
      <div className="max-w-7xl mx-auto">
        <div className="grid md:grid-cols-2 gap-20 items-center mb-32">
          <motion.div 
            whileInView={{ opacity: 1, x: 0 }}
            initial={{ opacity: 0, x: -50 }}
            viewport={{ once: true }}
          >
            <span className="text-[#A30B33] font-bold tracking-[0.4em] text-[10px] uppercase mb-6 block">// Misja Wydziału</span>
            <h2 className="text-5xl md:text-6xl font-black text-[#111827] mb-8 tracking-tight uppercase italic">
              Edukacja <br /> <span className="text-[#A30B33]">Bez Granic</span> Technicznych.
            </h2>
            <p className="text-lg text-slate-500 leading-relaxed mb-12 font-light italic border-l-4 border-slate-100 pl-8">
              "Przygotowujemy do pracy w gospodarce opartej na wiedzy, wdrażając innowacyjne metody nauczania oparte na projektach i współpracy z biznesem."
            </p>
            
            <div className="grid grid-cols-2 gap-y-12 gap-x-8">
              <Counter from={0} to={50} label="Lat tradycji" />
              <Counter from={0} to={15000} label="Absolwentów" />
              <Counter from={0} to={300} label="Firm partnerskich" />
              <Counter from={0} to={20} label="Kół Naukowych" />
            </div>
          </motion.div>

          <motion.div 
            whileInView={{ opacity: 1, scale: 1 }}
            initial={{ opacity: 0, scale: 0.95 }}
            viewport={{ once: true }}
            className="relative h-[600px] rounded-[3rem] overflow-hidden shadow-2xl rotate-2 hover:rotate-0 transition-transform duration-700"
          >
            <Image 
              src="/hero-campus.png" 
              alt="Wydział Zarządzania AGH"
              fill
              className="object-cover"
            />
            <div className="absolute inset-0 bg-gradient-to-t from-[#111827]/60 to-transparent" />
          </motion.div>
        </div>
      </div>
    </section>

    {/* SEKCJA 3: KIERUNKI */}
    <MajorSection />

    {/* SEKCJA 4: KATEDRY */}
    <section id="katedry" className="min-h-screen bg-[#F9FAFB] py-24 px-8">
        <div className="max-w-7xl mx-auto w-full">
            <div className="flex flex-col md:flex-row justify-between items-end mb-20 gap-8">
                <div className="max-w-3xl">
                    <h2 className="text-5xl font-black mb-8 uppercase tracking-tighter italic">
                        Struktura <span className="text-[#A30B33]">Naukowa</span>
                    </h2>
                    <p className="text-slate-500 text-lg leading-relaxed">
                        Wydział tworzy 6 wyspecjalizowanych katedr, realizujących badania w zakresie nauk o zarządzaniu i jakości oraz ekonomii i finansów.
                    </p>
                </div>
                <a href="/departments" className="bg-[#111827] text-white px-8 py-4 rounded-xl text-xs font-bold tracking-widest hover:bg-[#A30B33] transition-colors uppercase">
                    Wszystkie Katedry
                </a>
            </div>

            <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                {[
                    { t: 'Zastosowań Informatyki', d: 'Systemy ERP, Business Intelligence oraz AI w procesach decyzyjnych.', code: 'KZI' },
                    { t: 'Inżynierii Zarządzania', d: 'Zarządzanie produkcją, jakością i inżynieria systemów społeczno-technicznych.', code: 'KIZ' },
                    { t: 'Ekonomii i Finansów', d: 'Analiza rynkowa, ekonometria oraz finanse przedsiębiorstw.', code: 'KEF' },
                    { t: 'Zarządzania Operacyjnego', d: 'Logistyka, badania operacyjne i modelowanie łańcuchów dostaw.', code: 'KZO' },
                    { t: 'Kapitału Ludzkiego', d: 'Psychologia pracy, HR oraz zarządzanie wiedzą w organizacji.', code: 'KKL' },
                    { t: 'Zarządzania Przedsiębiorstwem', d: 'Przedsiębiorczość, strategie rozwoju i zarządzanie projektami.', code: 'KZP' }
                ].map((cat, i) => (
                    <motion.div 
                        key={i}
                        whileHover={{ y: -8 }}
                        className="bg-white p-12 rounded-3xl border border-slate-100 shadow-sm hover:shadow-xl transition-all relative overflow-hidden group"
                    >
                        <div className="absolute top-0 right-0 p-8 text-slate-50 font-black text-6xl group-hover:text-slate-100 transition-colors z-0 uppercase tracking-tighter">
                            {cat.code}
                        </div>
                        <div className="relative z-10">
                            <div className="w-8 h-8 rounded-lg bg-slate-50 flex items-center justify-center mb-8 group-hover:bg-[#A30B33] group-hover:text-white transition-colors">
                                <span className="text-[10px] font-bold italic">{i+1}</span>
                            </div>
                            <h3 className="font-black text-xl mb-4 text-[#111827] uppercase leading-tight">Katedra <br/>{cat.t}</h3>
                            <p className="text-slate-500 text-sm font-light leading-relaxed">{cat.d}</p>
                        </div>
                    </motion.div>
                ))}
            </div>
        </div>
    </section>

    <BentoGrid />

    {/* SEKCJA 5: KONTAKT */}
    <section id="kontakt" className="min-h-screen bg-white flex items-center justify-center py-24 px-8">
        <div className="max-w-7xl w-full mx-auto grid lg:grid-cols-2 gap-24">
            <motion.div initial={{ opacity: 0, x: -30 }} whileInView={{ opacity: 1, x: 0 }} viewport={{ once: true }}>
                <h2 className="text-7xl font-black text-[#111827] mb-12 tracking-tighter uppercase italic">
                    Kontakt.
                </h2>
                <div className="space-y-12">
                    <div className="group">
                        <p className="text-[#A30B33] font-mono text-xs uppercase tracking-[0.4em] mb-4 font-bold">// Adres</p>
                        <p className="text-3xl font-bold text-[#111827]">ul. Gramatyka 10, 30-067 Kraków</p>
                        <p className="text-slate-400 mt-2 font-light uppercase tracking-widest text-sm italic">Budynek D-14, AGH</p>
                    </div>
                    <div className="grid grid-cols-2 gap-8">
                        <div>
                            <p className="text-[#A30B33] font-mono text-xs font-bold uppercase tracking-widest mb-4">// Centrala</p>
                            <p className="text-xl font-black">+48 12 617 38 30</p>
                        </div>
                        <div>
                            <p className="text-[#A30B33] font-mono text-xs font-bold uppercase tracking-widest mb-4">// E-mail</p>
                            <p className="text-xl font-black">wz@agh.edu.pl</p>
                        </div>
                    </div>
                </div>
            </motion.div>

            <motion.div 
                initial={{ opacity: 0, y: 30 }}
                whileInView={{ opacity: 1, y: 0 }}
                viewport={{ once: true }}
                className="bg-[#111827] rounded-[3rem] p-12 text-white relative overflow-hidden shadow-2xl flex flex-col justify-between"
            >
                <div>
                    <h3 className="text-3xl font-black mb-12 italic tracking-tight">Władze <span className="text-[#A30B33]">Wydziału</span></h3>
                    <div className="space-y-10">
                        <div className="flex items-center gap-8">
                            <div className="w-20 h-20 bg-slate-800 rounded-2xl border border-white/10 flex items-center justify-center text-2xl font-black italic text-[#A30B33]">DZ</div>
                            <div>
                                <p className="text-[#A30B33] font-mono text-[10px] uppercase font-bold tracking-[0.3em]">Dziekan Wydziału</p>
                                <p className="text-2xl font-bold tracking-tight">prof. dr hab. inż. Marek Lutyński</p>
                            </div>
                        </div>
                        <div className="p-8 bg-white/5 rounded-3xl border border-white/5 backdrop-blur-md">
                            <h4 className="font-bold mb-4 text-[10px] uppercase tracking-widest text-slate-400 font-mono">Sekretariat Dziekana</h4>
                            <p className="text-slate-300">Pokój 114, I piętro</p>
                            <p className="text-xl font-bold mt-2">Pon. - Pt. | 10:00 - 13:00</p>
                        </div>
                    </div>
                </div>
                <button className="mt-12 w-full bg-[#A30B33] hover:bg-white hover:text-[#111827] py-5 rounded-2xl font-black transition-all duration-500 uppercase tracking-widest text-xs">
                    Wirtualny Dziekanat
                </button>
            </motion.div>
        </div>
    </section>

    {/* STOPKA */}
    <footer className="bg-[#111827] text-white pt-24 pb-12 px-8 border-t border-white/5">
        <div className="max-w-7xl mx-auto flex flex-col md:flex-row justify-between items-start gap-16 mb-24">
            <div className="max-w-md">
                <div className="text-3xl font-black italic mb-8">AGH <span className="text-[#A30B33]">WZ</span></div>
                <p className="text-slate-500 font-light leading-relaxed">
                    Kształtujemy liderów potrafiących zarządzać w oparciu o dane i technologie. 
                    Najlepszy wydział zarządzania na uczelni technicznej w Polsce.
                </p>
            </div>
            <div className="grid grid-cols-2 md:grid-cols-3 gap-16 text-sm">
                <div>
                    <h4 className="font-bold mb-6 text-[#A30B33] uppercase font-mono text-[10px] tracking-widest">Wydział</h4>
                    <ul className="space-y-3 text-slate-400">
                        <li><a href="#owydziale" className="hover:text-white transition-colors">O nas</a></li>
                        <li><a href="#kierunki" className="hover:text-white transition-colors">Edukacja</a></li>
                        <li><a href="#katedry" className="hover:text-white transition-colors">Nauka</a></li>
                    </ul>
                </div>
                <div>
                    <h4 className="font-bold mb-6 text-[#A30B33] uppercase font-mono text-[10px] tracking-widest">Informacje</h4>
                    <ul className="space-y-3 text-slate-400">
                        <li><a href="#" className="hover:text-white transition-colors">Aktualności</a></li>
                        <li><a href="#" className="hover:text-white transition-colors">Rekrutacja</a></li>
                        <li><a href="#" className="hover:text-white transition-colors">Dla Mediów</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div className="max-w-7xl mx-auto pt-12 border-t border-white/5 flex flex-col md:flex-row justify-between items-center gap-8 text-[10px] font-mono text-slate-600 uppercase tracking-[0.3em]">
            <p>© 2026 Wydział Zarządzania AGH. Wszystkie prawa zastrzeżone.</p>
            <div className="flex gap-8 italic">
                <span>W3C Valid HTML5</span>
                <span>WCAG 2.1 Compliant</span>
            </div>
        </div>
    </footer>
    </main>
  );
}