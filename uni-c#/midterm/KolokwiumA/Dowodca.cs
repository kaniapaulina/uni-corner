using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumA
{
    public class Dowodca : Mieszkaniec
    {
        string tytul;

        public string Tytul { get => tytul; 
            set 
            { 
                if (string.IsNullOrEmpty(value) || value.Length < 3 || !char.IsUpper(value[0]))
                    throw new ZlyTytulException("Tytuł jest zły");
                tytul = value;
            }
        }

        public Dowodca():base()
        {
            this.tytul = "Dowódca";
        }

        public Dowodca(string imie, string miasto,  decimal waga, double szybkosc, string tytul) : base(imie, miasto,  waga, szybkosc)
        {
            this.tytul = tytul;
        }

        public override double Moc()
        {
            return base.Moc() *50;
        }

        

        public override string ToString()
        {
            return $"{Tytul} z miasta {Miasto} - {Imie}";
        }
    }
}
