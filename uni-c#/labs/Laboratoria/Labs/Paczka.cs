using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoria.Labs
{
    internal class Paczka
    {
        static int _aktualnyNumer;
        static float _oplataZaKg;

        string _nadawca;
        int _rozmiar;
        string _numerPaczki;

        public static int AktualnyNumer { get => _aktualnyNumer; set => _aktualnyNumer = value; }
        public static float OplataZaKg { get => _oplataZaKg; set => _oplataZaKg = value; }
        public string Nadawca { get => _nadawca; set => _nadawca = value; }
        public int Rozmiar { get => _rozmiar; set => _rozmiar = value; }
        public string NumerPaczki { get => _numerPaczki; set => _numerPaczki = value; }

        static Paczka()
        {
            _aktualnyNumer = 100;
            _oplataZaKg = 5.0f; //double na float
        }

        public Paczka()
        {
            _nadawca = string.Empty;
            _rozmiar = 0;
            _numerPaczki = $"P/{_aktualnyNumer}/2025"; //z daty systemowej pobrac rok
            _aktualnyNumer++;
        }

        public Paczka(string nadawca, int rozmiar) : this()
        {
            _nadawca = nadawca;
            _rozmiar = rozmiar;
        }
        public override string ToString()
        {
            return $"{_numerPaczki}, {_nadawca}, {Rozmiar}, koszt wysyłki: {KosztWysylki()}";
        }

        public virtual double KosztWysylki()
        {
            return (double)_oplataZaKg * Rozmiar;
        }



    }
}
