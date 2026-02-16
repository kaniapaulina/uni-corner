using Dnd_BBB;
using Dnd_BBB.Core;
using Dnd_BBB.Service;
using HandyControl;
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

namespace DndGUI
{
    /// <summary>
    /// Statyczny manager danych przechowujący listę postaci w pamięci operacyjnej (Cache).
    /// </summary>
    public static class AppCache
    {
        public static List<Character> Characters { get; set; } = new List<Character>();
        public static ObservableCollection<Party> Parties { get; set; } = new ObservableCollection<Party>();

        public static void SyncEditors()
        {
            var openEditors = Application.Current.Windows.OfType<EdycjaPostaciWindow>().ToList();
            foreach (var w in openEditors) w.RefreshCharacters(Characters);
        }
        public static void SyncAll()
        {
            var characterEditors = Application.Current.Windows.OfType<EdycjaPostaciWindow>().ToList();
            foreach (var w in characterEditors) w.RefreshCharacters(Characters);

            var partyEditors = Application.Current.Windows.OfType<EdycjaDruzynyWindow>().ToList();
            foreach (var w in partyEditors) w.RefreshPartiesFromCache();
        }
    }

    /// <summary>
    /// Główne okno aplikacji sterujące nawigacją między kreatorami a edytorami.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                AppCache.Characters = Party.ReadAllCharactersFromDb();

                var parties = Party.ReadFromDb();
                AppCache.Parties = new ObservableCollection<Party>(parties);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message);
                AppCache.Characters = new List<Character>();
                AppCache.Parties = new ObservableCollection<Party>();
            }
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
        }

        private void TworzeniePButton_Click(object sender, RoutedEventArgs e)
        {
            TworzeniePostaciWindow tworzeniePostaciWindow = new TworzeniePostaciWindow();
            tworzeniePostaciWindow.Show();
        }

        private void EdycjaPButton_Click(object sender, RoutedEventArgs e)
        {
            EdycjaPostaciWindow edycjaPostaciWindow = new EdycjaPostaciWindow();
            edycjaPostaciWindow.Show();
        }

        private void TworzenieDButton_Click(object sender, RoutedEventArgs e)
        {
            TworzenieDruzynyWindow tworzenieDruzynyWindow = new TworzenieDruzynyWindow();
            tworzenieDruzynyWindow.Show();
        }

        private void EdycjaDButton_Click(object sender, RoutedEventArgs e)
        {
            EdycjaDruzynyWindow edycjaDruzynyWindow = new EdycjaDruzynyWindow();
            edycjaDruzynyWindow.Show();
        }
    }
}