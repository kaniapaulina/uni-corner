using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KolokwiumB
{
    public class Firma
    {
        string nazwaFirmy;
        List<Telefon> telefonyFirmowe = new List<Telefon>();

        public Firma()
        {
            this.nazwaFirmy = string.Empty;
        }

        public Firma(string nazwaFirmy):this()
        {
            this.nazwaFirmy = nazwaFirmy;
        }

        public string NazwaFirmy { get => nazwaFirmy; 
            set
            {
                const string wzorzec = @"^[A-Z].*$";
                if(!Regex.IsMatch(value, wzorzec))
                {
                    throw new FormatException("Zla nazwa firmy");
                }
                nazwaFirmy = value;
            } 
        }
        public List<Telefon> TelefonyFirmowe { get => telefonyFirmowe; set => telefonyFirmowe = value; }

        public void DodajTelefon(Telefon telefon)
        {
            telefonyFirmowe.Add(telefon);
        }

        public void UsunTelefon(Telefon telefon)
        {
            if(telefonyFirmowe.Contains(telefon))
            {
                telefonyFirmowe.Remove(telefon);
            }
        }

        public List<TelefonKomórkowy> Wyszukaj(EnumOperatorSieci operatorSieci)
        {
            List<TelefonKomórkowy> znalezione = new List<TelefonKomórkowy>();
            foreach(TelefonKomórkowy tk in telefonyFirmowe)
            {
                if (tk.OperatorSieci.Equals(operatorSieci)) {
                    znalezione.Add(tk);
                }
            }
            return znalezione;

            //return telefonyFirmowe.OfType<TelefonKomórkowy>().Where(tk => tk,OperatorSieci.Equals(operatorSieci)).ToList();
        }

        public decimal SumaBillingow()
        {
            decimal suma = 0M;
            foreach(var tel in telefonyFirmowe)
            {
                suma += tel.SumaBillingu();
            }
            return suma;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Firma: {nazwaFirmy} [{SumaBillingow()}]");
            foreach (var tel in telefonyFirmowe)
            {
                sb.AppendLine(tel.ToString());
            }
            return sb.ToString();
        }

        public static void ZapiszXML(string nazwa, Firma firma)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Firma));
                using (var stream = new StreamWriter(nazwa))
                    serializer.Serialize(stream, firma);
                Console.WriteLine("Udalo sie!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Firma OdczytajXML(string nazwa)
        {
            Firma odczytana = new Firma();
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Firma));
                using (var stream = new StreamReader(nazwa))
                    return (Firma)serializer.Deserialize(stream);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Nie ma takiego pliku");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

    }
}
