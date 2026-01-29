using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium_grupa_c
{
    public abstract class Renifer
    {
        string nazwisko;
        DateTime dataUrodzenia;
        decimal waga;
        string numerEwidencji;
        static int kolejnosc;

        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        public string NumerEwidencji { get => numerEwidencji; set => numerEwidencji = value; }
        public static int Kolejnosc { get => kolejnosc; set => kolejnosc = value; }
        public decimal Waga { get => waga;
            set 
            { 
                if (value<80)
                {
                    throw new GlowingNoseDoesntWorkException("To wyzysk, a nie Święta! Renifer chucherko nie pociągnie sań");
                }
                waga = value;
            } 
        }

        static Renifer()
        {
            kolejnosc = 120;
        }
        public Renifer()
        {
            this.nazwisko = "RENIFER";
            this.dataUrodzenia = DateTime.Now;
            this.waga = 100M;
            kolejnosc++;
            this.numerEwidencji = $"{nazwisko.Substring(0, 3).ToLower()}_{kolejnosc:D5}";
        }
        public Renifer(string nazwisko, DateTime dataUrodzenia, decimal waga) : this()
        {
            this.nazwisko = nazwisko;
            this.dataUrodzenia = dataUrodzenia;
            this.waga = waga;
            kolejnosc++;
            this.numerEwidencji = $"{nazwisko.Substring(0, 3).ToLower()}_{kolejnosc:D5}";

        }

        public virtual double ObliczUdzwig()
        {
            return (double)waga * 1.5;
        }

        public int Wiek(DateTime dataUrodzenia)
        {
            int age_lived = DateTime.Now.Year - dataUrodzenia.Year;
            return age_lived;
        }

        public override string ToString()
        {
            return $"\"{numerEwidencji} {nazwisko} (Wiek: {Wiek(dataUrodzenia)}, data urodzenia: {dataUrodzenia:yyyy-MMMM-dd}) udźwig: {ObliczUdzwig():F2}kg\"";
        }

    }
}
