using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using OsobaZespol;
namespace ZespolGUI
{  
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OsobaZespol.Zespol zespol;
        bool czyZmieniono = false;
        public MainWindow()
        {
            InitializeComponent();

            zespol = (OsobaZespol.Zespol)OsobaZespol.Zespol.OdczytajXML("zespol.xml");
            if (zespol is object)
            {
                LstCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.CzlonkowieZespolu);
                TxtNazwa.Text = zespol.NazwaZespolu;
                TxtKierownik.Text = zespol.KierownikZespolu.ToString();
            }
        }

        private void BtnZmien_Click(object sender, RoutedEventArgs e)
        {
            OsobaWindow okno = new OsobaWindow(zespol.KierownikZespolu);
            bool? result = okno.ShowDialog();
            if (result == true)
            {
                TxtKierownik.Text = zespol.KierownikZespolu .ToString();
            }
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            CzlonekZespolu cz = new CzlonekZespolu();
            OsobaWindow okno = new OsobaWindow(cz);
            bool? result = okno.ShowDialog();
            if (result == true)
            {
                zespol.DodajCzlonkaZespolu(cz); //dodajemy członka
                LstCzlonkowie.ItemsSource = new
                ObservableCollection<CzlonekZespolu>(zespol.CzlonkowieZespolu);
            }
        }

        private void BtnUsun_Click(object sender, RoutedEventArgs e)
        {
            if (LstCzlonkowie.SelectedIndex > -1)
            {
                zespol.UsunCzlonka(((CzlonekZespolu)LstCzlonkowie.SelectedItem).Pesel);
                LstCzlonkowie.ItemsSource = new
                ObservableCollection<CzlonekZespolu>(zespol.CzlonkowieZespolu);
            }
        }

        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                zespol.NazwaZespolu = TxtNazwa.Text;
                zespol.ZapiszXML(filename);
            }
        }

        private void BtnSortuj_Click(object sender, RoutedEventArgs e)
        {
            zespol.Sortuj();
            LstCzlonkowie.ItemsSource = new
                ObservableCollection<CzlonekZespolu>(zespol.CzlonkowieZespolu);
        }

        private void BtnSortujPesel_Click(object sender, RoutedEventArgs e)
        {
            zespol.SortujpoPesel();
            LstCzlonkowie.ItemsSource = new
                ObservableCollection<CzlonekZespolu>(zespol.CzlonkowieZespolu);
        }

        private void BtnUsunKilka_Click(object sender, RoutedEventArgs e)
        {
            if (LstCzlonkowie.SelectedItems.Count > 0)
            {
                var delete = LstCzlonkowie.SelectedItems.Cast<CzlonekZespolu>().ToList();
                foreach (var osoba in delete)
                {
                    zespol.UsunCzlonka(osoba.Pesel);
                }
                LstCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.CzlonkowieZespolu);
            }
        }

        private void ButtonZnajdz_Click(object sender, RoutedEventArgs e)
        {
            string funkcja = txtSzukanaFunkcja.Text.ToLower();
            var wyniki = zespol.CzlonkowieZespolu.Where(c => c.FunkcjaWZespole.ToLower().Contains(funkcja)).ToList();

            LstCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.CzlonkowieZespolu);
        }

        private void ZaladujZespol(string sciezka)
        {
            zespol = (OsobaZespol.Zespol)OsobaZespol.Zespol.OdczytajXML(sciezka);
            LstCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.CzlonkowieZespolu);
            TxtNazwa.Text = zespol.NazwaZespolu;
            TxtKierownik.Text = zespol.KierownikZespolu.ToString();
        }

        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Pliki XML (*.xml)|*.xml";
            if (dlg.ShowDialog() == true)
            {
                ZaladujZespol(dlg.FileName);
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (czyZmieniono)
            {
                MessageBoxResult result = MessageBox.Show("Czy chcesz zapisać zmiany przed wyjściem?", "Zapisywanie", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    MenuZapisz_Click(null, null);
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    e.Cancel = true; 
                }
            }
        }

        private void MenuWyjdz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnZmienCzlonka_Click(object sender, RoutedEventArgs e)
        {
            if (LstCzlonkowie.SelectedItem is CzlonekZespolu wybrany)
            {
                OsobaWindow okno = new OsobaWindow(wybrany);
                if (okno.ShowDialog() == true)
                {
                    LstCzlonkowie.ItemsSource = new ObservableCollection<CzlonekZespolu>(zespol.CzlonkowieZespolu);
                }
            }
        }
    }
}