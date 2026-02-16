using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumA
{
    public class Mieszkaniec
    {
        string imie;
        string miasto;
        DateTime dataurodzenia;
        decimal waga;
        double szybkosc;
        static int liczebnosc;

        static Mieszkaniec()
        {
            liczebnosc = 10;
        }

        public Mieszkaniec()
        {
            liczebnosc++;
        }

        public Mieszkaniec(string imie, string miasto, decimal waga, double szybkosc) : this()
        {
            this.imie = imie;
            this.miasto = miasto;
            this.waga = waga;
            this.szybkosc = szybkosc;
        }

        /*
        virtual public double Moc(decimal waga, double szybkosc)
        {
            double wynik = (double)waga*szybkosc;
            return wynik;
        }
        */
        virtual public double Moc() => szybkosc * (double)waga;


        public override string ToString()
        {
            return $"{imie} z miasta {miasto}, Moc: {Moc()}";
        }

        public string Imie { get => imie; set => imie = value; }
        public string Miasto { get => miasto; set => miasto = value; }
        public decimal Waga { get => waga; set => waga = value; }
        public double Szybkosc { get => szybkosc; set => szybkosc = value; }
        public static int Liczebnosc { get => liczebnosc; set => liczebnosc = value; }
    }
}
