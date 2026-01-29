using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KolokwiumB
{

    public class BlednyNumerTelefonuException : Exception
    {
        public BlednyNumerTelefonuException(string message) : base(message)
        {
        }
    }



    public interface IWydarzeniaTygodniowe
    {
        void Przypomnienie(DateTime data, string komunikat);
    }


    [XmlInclude(typeof(TelefonKomórkowy))]
    public class Telefon : IWydarzeniaTygodniowe, IComparable<Telefon>
    {
        string numerTelefonu;
        Abonent wlasciciel;
        List<decimal> billing = new List<decimal>();
        static decimal oplataPodstawowa;

        public string NumerTelefonu { get => numerTelefonu; 
            set 
            { 
                if(value.Length != 9)
                {
                    throw new BlednyNumerTelefonuException("Bledny numer telefonu");
                }
                numerTelefonu = value;
            } 
        }
        internal Abonent Wlasciciel { get => wlasciciel; set => wlasciciel = value; }
        public List<decimal> Billing { get => billing; set => billing = value; }
        public static decimal OplataPodstawowa { get => oplataPodstawowa; set => oplataPodstawowa = value; }

        static Telefon()
        {
            oplataPodstawowa = (decimal)0.1;
        }

        public Telefon()
        {
            this.billing = new List<decimal>();
        }

        public Telefon(string numerTelefonu, Abonent wlasciciel):this()
        {
            this.numerTelefonu = numerTelefonu;
            this.wlasciciel = wlasciciel;
        }

        public virtual decimal OplataZaRozmowe(float minuty)
        {
            return (decimal)minuty * oplataPodstawowa;
        }

        public void RejestracjaRozmowy(float minuty)
        {
            billing.Add(OplataZaRozmowe(minuty));
        }

        public void Przypomnienie(DateTime data, string komunikat)
        {
            if (data.DayOfWeek == DateTime.Today.DayOfWeek)
            {
                Console.WriteLine($"{DateTime.Today.ToShortDateString:dd-mm-yyyy}: Dziś jest sprawdzian");
            }
            //throw new NotImplementedException();
        }

        public int CompareTo(Telefon? other)
        {
            if (other == null) return 1;
            return this.SumaBillingu().CompareTo(other.SumaBillingu());
            //throw new NotImplementedException();
        }

        public decimal SumaBillingu() => billing.Sum();

        public override string ToString()
        {
            return $"{wlasciciel.Imie} {wlasciciel.Nazwisko} [PESEL: {wlasciciel.Pesel}], tel.: {numerTelefonu.Substring(0,3)}-{numerTelefonu.Substring(3,3)}-{numerTelefonu.Substring(6,3)} ({SumaBillingu():F2}zł)";
        }
    }
}
