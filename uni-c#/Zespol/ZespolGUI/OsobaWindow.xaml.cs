using OsobaZespol;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ZespolGUI
{
    /// <summary>
    /// Logika interakcji dla klasy OsobaWindow.xaml
    /// </summary>
    public partial class OsobaWindow : Window
    {
        Osoba osoba;
        public OsobaWindow()
        {
            InitializeComponent();
            TxtFunkcja.IsEnabled = false; //isEnabled = false - nie wchodzimy w interakcje, readOnly - presentujemy uzytkownikowi ale tez nie zmieniamy
            TxtDoswiadczenie.IsEnabled = false;
        }

        public OsobaWindow(Osoba os) : this()
        {
            osoba = os;
            if (osoba is KierownikZespolu osobaKierownik)
            {
                TxtDoswiadczenie.IsEnabled = true;
                TxtPESEL.Text = osobaKierownik.Pesel;
                TxtImie.Text = osobaKierownik.Imie;
                TxtNazwisko.Text = osobaKierownik.Nazwisko;
                TxtDataUrodzenia.Text = $"{osobaKierownik.DataUrodzenia:dd-MMM-yyyy}";
                TxtDoswiadczenie.Text = osobaKierownik.DoswiadczenieKierownika.ToString();
                ComboBox.Text = (osobaKierownik.Plec == EnumPlec.K) ? "Kobieta" : "Mężczyzna";
            } else { TxtFunkcja.IsEnabled = true; }
        }

        private void BtnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (TxtPESEL.Text != "" || TxtImie.Text != "" || TxtNazwisko.Text != "")
            {
                osoba.Pesel = TxtPESEL.Text;
                osoba.Imie = TxtImie.Text;
                osoba.Nazwisko = TxtNazwisko.Text;
                DateTime.TryParseExact(TxtDataUrodzenia.Text, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy",
 "dd-MMM-yy" }, null, DateTimeStyles.None, out DateTime date);
                osoba.DataUrodzenia = date;
                if (ComboBox.Text == "Kobieta")
                {
                    osoba.Plec = EnumPlec.K;
                }
                else
                {
                    osoba.Plec = EnumPlec.M;
                }
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
                
        }
    }
}
