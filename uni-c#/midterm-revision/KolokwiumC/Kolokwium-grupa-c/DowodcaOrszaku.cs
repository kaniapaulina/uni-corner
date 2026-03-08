using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium_grupa_c
{
    public class DowodcaOrszaku:Renifer
    {
        float bonusSwietlny;

        public DowodcaOrszaku():base()
        {
            this.bonusSwietlny = 10f;
        }

        public DowodcaOrszaku(string nazwisko, DateTime dataUrodzenia, decimal waga, float bonusSwietlny) : base(nazwisko, dataUrodzenia, waga)
        {
            this.bonusSwietlny = bonusSwietlny;
        }

        public override double ObliczUdzwig()
        {
            return base.ObliczUdzwig()*(-0.5);
        }

        public override string ToString()
        {
            return $"PRZEWODNIK: {Nazwisko}, waga: {Waga:F2}kg, jasność nosa: {bonusSwietlny}%";
        }

        public float BonusSwietlny { get => bonusSwietlny; set => bonusSwietlny = value; }
    }
}
