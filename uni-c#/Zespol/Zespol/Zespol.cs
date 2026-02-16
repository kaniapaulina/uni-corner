using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OsobaZespol
{
    /// <summary>
    /// Interfejs do zapisywania obiektu do pliku (XML).
    /// </summary>
    public interface IZapisywalna
    {
        /// <summary>
        /// Zapisuje obiekt do pliku XML.
        /// </summary>
        /// <param name="nazwa">Ścieżka i nazwa pliku wyjściowego.</param>
        /// <returns>True jeśli zapis powiódł się, w przeciwnym razie false.</returns>
        bool ZapiszXML(string nazwa);
    }

    /// <summary>
    /// Reprezentuje zespół osób: kierownika i listę członków.
    /// /// Klasa udostępnia metody do zarządzania członkami, sortowania, klonowania oraz zapisu/odczytu do/z XML/JSON.
    /// </summary>
    public class Zespol : ICloneable, IZapisywalna
    {
        #region EF
        [Key]
        public int ZespolId { get; set; }
        public virtual KierownikZespolu KierownikZespolu { get; set; }
        public virtual List<CzlonekZespolu> CzlonkowieZespolu { get; set; }

        // ZAPIS DO BAZY DANYCH
        public void SaveToDB()
        {
            using (var db = new ZespolDbContext()) 
            {
                Console.WriteLine("Zapisywanie zespołu...");
                db.SaveChanges();
                Console.WriteLine("Zapisano pomyślnie.");
            }
        }

        public void Q1()
        {
            using (var db = new ZespolDbContext())
            {
                var query1 = from b in db.Zespoly
                             orderby b.NazwaZespolu
                             select b;

                Console.WriteLine("Wszystkie zespoły w bazie:");
                foreach (var item in query1)
                {
                    Console.WriteLine(item.NazwaZespolu);
                }
            }
        }

        public void Q2()
        {
            using (var db = new ZespolDbContext())
            {
                var query2 = from b in db.Czlonkowie
                         join z in db.Zespoly on b.ZespolId equals z.ZespolId
                         where z.ZespolId == 1
                         select new { b, z.NazwaZespolu };

                Console.WriteLine("Wszyscy członkowie z pierwszego zespołu:");
                foreach (var item in query2)
                {
                    Console.WriteLine($"{item.NazwaZespolu}, {item.b.Imie}, {item.b.Nazwisko}");
                }
            }
                
        }

        public void Q3()
        {
            using (var db = new ZespolDbContext())
            {
                int maxId = db.Zespoly.Max(z => z.ZespolId);
                    var queryC = from c in db.Czlonkowie
                                    where c.ZespolId == maxId && c.FunkcjaWZespole == "Programista"
                                    select c;

                foreach (var p in queryC)
                {
                    Console.WriteLine($"Programista: {p.Imie} {p.Nazwisko}");
                }
            }
                
        }

        public static Zespol ReadZespolFromDB()
        {
            using (var db = new ZespolDbContext())
            {
                Zespol z = new Zespol();
                int zespolId = db.Zespoly.Max(res => res.ZespolId);

                var zbaza = db.Zespoly.Find(zespolId);

                if (zbaza != null)
                {
                    z.ZespolId = zbaza.ZespolId;
                    z.NazwaZespolu = zbaza.NazwaZespolu;
                    z.KierownikZespolu = zbaza.KierownikZespolu;
                    z.CzlonkowieZespolu = zbaza.CzlonkowieZespolu;
                }
                return z;
            }
        }

        #endregion EF

        // Enable-Migrations
        // Update-Database --Verbose


        private int liczbaAktywnychCzlonkowZespolu;
        private string nazwaZespolu;
        private KierownikZespolu kierownikZespolu;
        private List<CzlonekZespolu> czlonkowieZespolu; // lista o typu danych CzlonekZespolu

        /// <summary>
        /// Tworzy nowy, pusty zespół.
        /// </summary>
        public Zespol()
        {
            this.liczbaAktywnychCzlonkowZespolu = 0;
            this.kierownikZespolu = null;
            this.nazwaZespolu = string.Empty;
            this.czlonkowieZespolu = new List<CzlonekZespolu>();
        }

        /// <summary>
        /// Tworzy zespół z przypisanym kierownikiem i nazwą.
        /// </summary>
        /// <param name="nazwaZespolu">Nazwa zespołu.</param>
        /// <param name="kierownikZespolu">Obiekt kierownika zespołu.</param>
        public Zespol(string nazwaZespolu, KierownikZespolu kierownikZespolu) : this()
        {
            this.nazwaZespolu = nazwaZespolu;
            this.kierownikZespolu = kierownikZespolu;
        }

        /// <summary>
        /// Dodaje członka do zespołu. Jeśli członek jest aktywny, zwiększa licznik aktywnych członków.
        /// </summary>
        /// <param name="c">Obiekt <see cref="CzlonekZespolu"/> do dodania.</param>
        public void DodajCzlonkaZespolu(CzlonekZespolu c)
        {
            czlonkowieZespolu.Add(c);
            if (c.Aktywny)
            {
                liczbaAktywnychCzlonkowZespolu++;
            }
        }

        /// <summary>
        /// Usuwa członka zespołu na podstawie PESEL.
        /// </summary>
        /// <param name="pesel">PESEL członka do usunięcia.</param>
        public void UsunCzlonka(string pesel)
        {
            if (JestCzlonkiem(pesel))
            {
                czlonkowieZespolu.Remove(czlonkowieZespolu.Find(c => c.Pesel == pesel));
            }
        }

        /// <summary>
        /// Usuwa wszystkich członków z zespołu.
        /// </summary>
        public void UsunWszystkich()
        {
            czlonkowieZespolu.Clear();
        }


        /// <summary>
        /// Zwraca czytelne, wielowierszowe przedstawienie obiektu zespołu.
        /// </summary>
        /// <returns>Tekstowy opis zespołu, kierownika i członków.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Zespół: {nazwaZespolu}");
            sb.AppendLine($"Liczba aktywnych członków zespołu: {liczbaAktywnychCzlonkowZespolu}");
            sb.AppendLine($"Kierownik zespołu: {kierownikZespolu}");
            foreach (var czlonek in czlonkowieZespolu)
            {
                sb.AppendLine(czlonek.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Wyszukuje nieaktywnych członków zespołu.
        /// </summary>
        /// <returns>Lista obiektów <see cref="CzlonekZespolu"/> z właściwością <c>Aktywny == false</c>.</returns>
        public List<CzlonekZespolu> WyszukajNieaktywnychCzlonkow()
        {
            return czlonkowieZespolu.Where(c => c.Aktywny == false).ToList();
        }

        /// <summary>
        /// Sortuje listę członków domyślnym porządkiem określonym przez <see cref="CzlonekZespolu.CompareTo"/>.
        /// </summary>
        public void Sortuj()
        {
            if (czlonkowieZespolu == null || czlonkowieZespolu.Count <= 1) { return; }
            czlonkowieZespolu.Sort();
        }

        /// <summary>
        /// Sortuje listę członków po PESEL przy użyciu komparatora PESEL.
        /// </summary>
        public void SortujpoPesel()
        {
            czlonkowieZespolu.Sort(new PESELComparator());
        }

        /// <summary>
        /// Sortuje listę członków malejąco po wieku.
        /// </summary>
        public void SortujpoWiek()
        {
            czlonkowieZespolu = czlonkowieZespolu.OrderByDescending(c => c.Wiek()).ToList();
        }

        /// <summary>
        /// Płytkie klonowanie obiektu (memberwise clone).
        /// </summary>
        /// <returns>Nowy obiekt będący płytką kopią bieżącego obiektu.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Tworzy głęboką kopię zespołu: kopiuje kierownika i listę członków (każdy członek jest klonowany).
        /// </summary>
        /// <returns>Nowy obiekt <see cref="Zespol"/> będący głęboką kopią.</returns>
        public Zespol DeepCopy()
        {
            Zespol kopia = (Zespol)this.Clone();
            kopia.nazwaZespolu = this.nazwaZespolu;
            kopia.KierownikZespolu = (KierownikZespolu)this.KierownikZespolu.Clone();
            kopia.czlonkowieZespolu = new List<CzlonekZespolu>(czlonkowieZespolu.Select(
                x => (CzlonekZespolu)x.Clone()));

            return kopia;
        }

        /// <summary>
        /// Zapisuje bieżący obiekt zespołu do pliku XML.
        /// </summary>
        /// <param name="nazwa">Ścieżka i nazwa pliku XML do zapisu.</param>
        /// <returns>True, jeśli zapis przebiegł pomyślnie.</returns>
        public bool ZapiszXML(string nazwa)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Zespol));
            StreamWriter sw = new StreamWriter(nazwa);
            serializer.Serialize(sw, this);
            sw.Close();
            return true;
        }

        /// <summary>
        /// Statyczna metoda zapisująca reprezentację zespołu do pliku XML.
        /// </summary>
        /// <param name="nazwa">Ścieżka i nazwa pliku XML.</param>
        /// <param name="zespol">Napis reprezentujący zespół (zwykle powinien być obiektem Zespol; tu przyjęto string).</param>
        public static void ZapiszXML(string nazwa, string zespol)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Zespol));
                using (StreamWriter writer = new StreamWriter(nazwa))
                {
                    serializer.Serialize(writer, zespol);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Odczytuje zespół z pliku XML.
        /// </summary>
        /// <param name="nazwa">Ścieżka i nazwa pliku XML do odczytu.</param>
        /// <returns>Obiekt <see cref="Zespol"/> odczytany z pliku lub null jeśli plik nie istnieje.</returns>
        public static Zespol OdczytajXML(string nazwa)
        {
            Zespol odczytany = new Zespol();
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Zespol));
                using (TextReader reader = new StreamReader(nazwa))
                {
                    odczytany = (Zespol)serializer.Deserialize(reader);
                }
                return odczytany;
            }
            catch (FileNotFoundException) { Console.WriteLine("Nie ma pliku"); }

            return null;
        }

        /// <summary>
        /// Zapisuje obiekt zespołu do pliku JSON.
        /// </summary>
        /// <param name="nazwa">Ścieżka i nazwa pliku JSON.</param>
        /// <param name="z">Obiekt <see cref="Zespol"/> do zapisania.</param>
        public static void ZapiszJSON(string nazwa, Zespol z)
        {
            DataContractJsonSerializer jser = new DataContractJsonSerializer(typeof(Zespol));
            using (var fstream = File.Create(nazwa))
            {
                jser.WriteObject(fstream, z);
            }
        }

        /// <summary>
        /// Odczytuje obiekt zespołu z pliku JSON.
        /// </summary>
        /// <param name="nazwa">Ścieżka i nazwa pliku JSON.</param>
        /// <returns>Obiekt <see cref="Zespol"/> odczytany z JSON lub nowy obiekt jeśli plik nie istnieje.</returns>
        public static Zespol OdczytajJSON(string nazwa)
        {
            Zespol odczytany = new Zespol();
            try
            {
                FileStream fs = new FileStream(nazwa, FileMode.Open);
                DataContractJsonSerializer jsonSr = new DataContractJsonSerializer(typeof(Zespol));
                fs.Position = 0;
                odczytany = (Zespol)jsonSr.ReadObject(fs);
                fs.Close();
                return odczytany;
            }
            catch (FileNotFoundException) { Console.WriteLine("Nie znaleziono pliku"); }

            return odczytany;
        }


        /// <summary>
        /// Sprawdza czy w zespole istnieje członek o zadanym PESEL.
        /// </summary>
        /// <param name="pesel">PESEL do wyszukania.</param>
        /// <returns>True jeśli istnieje członek z danym PESEL, w przeciwnym razie false.</returns>
        public bool JestCzlonkiem(string pesel)
        {
            return czlonkowieZespolu.Exists(c => c.Pesel == pesel);
        }

        /// <summary>
        /// Sprawdza czy w zespole istnieje dany obiekt członka (porównanie przez Equals).
        /// </summary>
        /// <param name="cz">Obiekt <see cref="CzlonekZespolu"/> do sprawdzenia.</param>
        /// <returns>True jeśli istnieje równoważny członek w zespole.</returns>
        public bool JestCzlonkiem(CzlonekZespolu cz)
        {
            return czlonkowieZespolu.Exists(c => c.Equals(cz));
        }

        /// <summary>
        /// Sprawdza czy w zespole istnieje członek o podanym imieniu i nazwisku.
        /// </summary>
        /// <param name="nazwisko">Nazwisko członka.</param>
        /// <param name="imie">Imię członka.</param>
        /// <returns>True jeśli znaleziono dopasowanie, inaczej false.</returns>
        public bool JestCzlonkiem(string nazwisko, string imie)
        {
            bool jest = false;
            foreach (CzlonekZespolu c in czlonkowieZespolu)
            {
                if (c.Imie == imie && c.Nazwisko == nazwisko)
                {
                    jest = true;
                }
            }
            return jest;
        }


        /// <summary>
        /// Wyszukuje członków zespołu pełniących zadaną funkcję.
        /// </summary>
        /// <param name="funkcja">Nazwa funkcji/stanowiska wewnątrz zespołu.</param>
        /// <returns>Lista członków pełniących podaną funkcję.</returns>
        public List<CzlonekZespolu> WyszukajFunkcje(string funkcja)
        {
            List<CzlonekZespolu> mlist = new List<CzlonekZespolu>();
            mlist = czlonkowieZespolu.FindAll(c => c.FunkcjaWZespole.Equals(funkcja));
            return mlist;
        }

        /// <summary>
        /// Liczba aktywnych członków zespołu.
        /// </summary>
        public int LiczbaAktywnychCzlonkowZespolu { get => liczbaAktywnychCzlonkowZespolu; set => liczbaAktywnychCzlonkowZespolu = value; }

        /// <summary>
        /// Nazwa zespołu.
        /// </summary>
        public string NazwaZespolu { get => nazwaZespolu; set => nazwaZespolu = value; }

        /// <summary>
        /// Kierownik zespołu.
        /// </summary>
        //public KierownikZespolu KierownikZespolu { get => kierownikZespolu; set => kierownikZespolu = value; }

        /// <summary>
        /// Lista członków zespołu.
        /// </summary>
        //public List<CzlonekZespolu> CzlonkowieZespolu { get => czlonkowieZespolu; set => czlonkowieZespolu = value; }
    }
}
