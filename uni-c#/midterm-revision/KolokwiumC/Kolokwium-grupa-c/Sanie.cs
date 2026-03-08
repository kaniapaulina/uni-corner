using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kolokwium_grupa_c
{
    [XmlInclude(typeof(ReniferPociagowy))]
    [XmlInclude(typeof(DowodcaOrszaku))]
    public class Sanie
    {
        string nazwa;
        DowodcaOrszaku dowodca;
        Dictionary<string, ReniferPociagowy> zaprzeg;

        public Sanie()
        {
            this.zaprzeg = new Dictionary<string, ReniferPociagowy>();
        }

        public Sanie(string nazwa, DowodcaOrszaku dowodca):this()
        {
            this.nazwa = nazwa;
            this.dowodca = dowodca;
        }

        public void Zaprzegnij(ReniferPociagowy r)
        {
            if(r.ObliczUdzwig() >= 150)
            {
                zaprzeg.Add(r.NumerEwidencji, r);
            }
        }

        public double CalkowityUdzwigSan()
        {
            double suma = 0;
            double bonus = 1+dowodca.BonusSwietlny / 100;
            foreach(var r in zaprzeg)
            {
                suma += r.Value.ObliczUdzwig() * bonus;
            }
            return suma;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nazwa: {nazwa} i dowodctwo: {dowodca} z calkowitym udżwigiem: {CalkowityUdzwigSan():F2}\n");
            foreach( var r in zaprzeg)
            {
                sb.Append($"{r.Value}\n");
            }
            return sb.ToString();
        }

        public void Sort()
        {
            zaprzeg = zaprzeg.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }


        public void SortAlfabetycznie()
        {
            var comparer = new ReniferComparer();
            zaprzeg = zaprzeg.OrderBy(x => x.Value, comparer)
                             .ToDictionary(x => x.Key, x => x.Value);
        }


        public static void ZapiszSanieDlaMikolajaXMLDC(string plik, Sanie sanie)
        {
            try
            {
            XmlSerializer serializer = new XmlSerializer(typeof(Sanie));
                using (var writer = new StreamWriter(plik))
                {
                    serializer.Serialize(writer, sanie);
                }
                Console.WriteLine("Udalo sie");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        public static Sanie OdczytajXML(string plik)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Sanie));
                using (var reader = new StreamReader(plik))
                { return (Sanie)serializer.Deserialize(reader); }

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return null;
        }

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public DowodcaOrszaku Dowodca { get => dowodca; set => dowodca = value; }

        [XmlIgnore]
        public Dictionary<string, ReniferPociagowy> Zaprzeg { get => zaprzeg; set => zaprzeg = value; }
        
        [XmlArray("ListaZaprzegu")]
        public List<ReniferPociagowy> ZaprzegDlaXml
        {
            get { return zaprzeg.Values.ToList(); }
            set { zaprzeg = value.ToDictionary(r => r.NumerEwidencji, r => r); }
        }
    }
}
