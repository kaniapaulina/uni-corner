using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paczkomat
{
    internal class Paczka
    {
        static int _aktualnyNumer;
        static float _oplataZaKg;

        private string _nadawca;
        private int _rozmiar;
        private string _numerPaczki;

        static Paczka()
        {
            _aktualnyNumer = 100;
            _oplataZaKg = 5.0f;
        }

        public Paczka()
        {
            _nadawca = string.Empty;
            _rozmiar = 0;
            _numerPaczki = $"P/{_aktualnyNumer}/{DateTime.Today:yyyy}"; 
            _aktualnyNumer++;
        }

        public Paczka(string nadawca, int rozmiar) : this()
        {
            this._nadawca = nadawca;
            this._rozmiar = rozmiar;
        }

        virtual public double KosztWysylki()
        {
            return _rozmiar * _oplataZaKg;
        }

        public override string ToString()
        {
            return $"{_numerPaczki} Nadawca: {_nadawca}, Rozmiar: {_rozmiar}kg, Koszt wysyłki: {KosztWysylki():0.00} PLN";
        }

        public static int AktualnyNumer { get => _aktualnyNumer; set => _aktualnyNumer = value; }
        public static float OplataZaKg { get => _oplataZaKg; set => _oplataZaKg = value; }
        public string Nadawca { get => _nadawca; set => _nadawca = value; }
        public int Rozmiar { get => _rozmiar; set => _rozmiar = value; }
        public string NumerPaczki { get => _numerPaczki; set => _numerPaczki = value; }
    }
}
