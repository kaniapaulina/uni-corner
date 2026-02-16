using Dnd_BBB.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace DndGUI
{
    /// <summary>
    /// Okno tworzenia nowej drużyny. Pozwala na wybór postaci z bazy 
    /// i grupowanie ich pod wspólną nazwą zespołu.
    /// </summary>
    public partial class TworzenieDruzynyWindow : Window
    {
        private ObservableCollection<Character> partyMembers = new ObservableCollection<Character>();

        public TworzenieDruzynyWindow()
        {
            InitializeComponent();
            listBoxCharacters.ItemsSource = partyMembers;
            cmbPostaci.ItemsSource = AppCache.Characters;
            listBoxCharacters.DisplayMemberPath = "Name";
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            if (cmbPostaci.SelectedItem is Character hero)
            {
                if (partyMembers.Any(p => p.Name == hero.Name))
                {
                    MessageBox.Show("Ta postać jest już w Twojej drużynie.");
                    return;
                }

                partyMembers.Add(hero);
                cmbPostaci.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Wybierz postać z listy przed dodaniem.");
            }
        }

        private void ZapiszDruzyny_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazwa.Text))
            {
                MessageBox.Show("Podaj nazwę drużyny!");
                return;
            }

            var party = new Party(txtNazwa.Text.Trim());
            party.PartyMembers = partyMembers.ToList();

            party.SaveToDb(party);
            AppCache.Parties = new ObservableCollection<Party>(Party.ReadFromDb());

            AppCache.SyncAll();
            this.Close();
        }
    }
}
