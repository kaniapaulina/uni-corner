using System;
using System.Collections.Generic;
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
using HandyControl;
using Dnd_BBB;
using Dnd_BBB.Core;
using Dnd_BBB.Classes;
using Dnd_BBB.Races;
using Dnd_BBB.Service;
using Dnd_BBB.Exceptions;

namespace DndGUI
{
    /// <summary>
    /// Okno kreacji bohatera. Obsługuje automatyczne losowanie statystyk (StatService) 
    /// oraz walidację dostępności czarów dla konkretnych klas.
    /// </summary>
    public partial class TworzeniePostaciWindow : Window
    {
        private Character character = new Character();
        private bool rollClicked = false;

        public TworzeniePostaciWindow()
        {
            InitializeComponent();
        }
        private void CmbKlasaPostaci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateClassAndSpells();
        }

        private void UpdateClassAndSpells()
        {
            if (txtSpell1 == null || txtSpell2 == null || txtSpell3 == null || txtSpell4 == null)
                return;

            string selectedClass = (cmbKlasaPostaci.SelectedItem as ComboBoxItem)?.Content.ToString();

            character.UnitClass = GetClass(selectedClass);
            bool canCast = character.UnitClass?.Spell ?? false;

            txtSpell1.IsEnabled = txtSpell2.IsEnabled = txtSpell3.IsEnabled = txtSpell4.IsEnabled = canCast;
            if (!canCast) txtSpell1.Text = txtSpell2.Text = txtSpell3.Text = txtSpell4.Text = "";
        }
        
        private UnitClass? GetClass(string name)
        {
            return name switch
            {
                "Bard" => new Bard(),
                "Barbarian" => new Barbarian(),
                "Cleric" => new Cleric(),
                "Druid" => new Druid(),
                "Fighter" => new Fighter(),
                "Monk" => new Monk(),
                "Paladin" => new Paladin(),
                "Ranger" => new Ranger(),
                "Rogue" => new Rogue(),
                "Sorcerer" => new Sorcerer(),
                "Warlock" => new Warlock(),
                "Wizard" => new Wizard(),
                _ => null
            };
        }

        private UnitRace? GetRace(string name)
        {
            return name switch
            {
                "Human" => new Human(),
                "Elf" => new Elf(),
                "Dwarf" => new Dwarf(),
                "Halfling" => new Halfling(),
                "Dragonborn" => new Dragonborn(),
                "Gnome" => new Gnome(),
                "Half-Orc" => new Half_Orc(),
                "Half-Elf" => new Half_Elf(),
                "Tiefling" => new Tiefling(),
                _ => null
            };
        }

        private void FillStats()
        {
            losStr.Text = character.Str.ToString();
            losDex.Text = character.Dext.ToString();
            losInt.Text = character.Intel.ToString();
            losWis.Text = character.Wis.ToString();
            losChar.Text = character.Charm.ToString();
            losConst.Text = character.Cons.ToString();
        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazwaPostaci.Text))
            {
                MessageBox.Show("Wpisz imię bohatera, zanim rzucisz kośćmi!");
                return;
            }
            if (rollClicked) return;

            DiceRollWindow animationWindow = new DiceRollWindow { Owner = this };
            animationWindow.ShowDialog();
            string selectedClass = (cmbKlasaPostaci.SelectedItem as ComboBoxItem)?.Content.ToString();
            string selectedRace = (cmbRasaPostaci.SelectedItem as ComboBoxItem)?.Content.ToString();

            character.UnitClass = GetClass(selectedClass);
            character.UnitRace = GetRace(selectedRace);

            if (character.UnitClass != null && character.UnitRace != null)
            {
                character.UnitClass.AssignStats(character);
                FillStats();
                rollClicked = true;
                ((Button)sender).IsEnabled = false;
                UpdateClassAndSpells();
            }
            else
            {
                losStr.Text = losDex.Text = losInt.Text = losWis.Text = losChar.Text = losConst.Text = "0";
            }

            btnZapiszPostac.IsEnabled = true;

        }

        private void ZapiszButton_Click(Object sender, RoutedEventArgs e)
        {

            character.Name = txtNazwaPostaci.Text;
            character.AddProficiencies(txtUmiejetnosc1.Text, txtUmiejetnosc2.Text, txtUmiejetnosc3.Text);


            try
            {
                if (!string.IsNullOrWhiteSpace(txtSpell1.Text))
                {
                    if (character.UnitClass?.Spell ?? false) character.AddSpell(txtSpell1.Text);
                    else MessageBox.Show("Ta klasa nie może mieć zaklęć.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if (!string.IsNullOrWhiteSpace(txtSpell2.Text))
                {
                    if (character.UnitClass?.Spell ?? false) character.AddSpell(txtSpell2.Text);
                    else MessageBox.Show("Ta klasa nie może mieć zaklęć.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if (!string.IsNullOrWhiteSpace(txtSpell3.Text))
                {
                    if (character.UnitClass?.Spell ?? false) character.AddSpell(txtSpell3.Text);
                    else MessageBox.Show("Ta klasa nie może mieć zaklęć.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if (!string.IsNullOrWhiteSpace(txtSpell4.Text))
                {
                    if (character.UnitClass?.Spell ?? false) character.AddSpell(txtSpell4.Text);
                    else MessageBox.Show("Ta klasa nie może mieć zaklęć.S", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy dodawaniu zaklęć: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (int.TryParse(losStr.Text, out var strValue)) character.Str = strValue;
            if (int.TryParse(losDex.Text, out var dexValue)) character.Dext = dexValue;
            if (int.TryParse(losInt.Text, out var intValue)) character.Intel = intValue;
            if (int.TryParse(losWis.Text, out var wisValue)) character.Wis = wisValue;
            if (int.TryParse(losChar.Text, out var charValue)) character.Charm = charValue;
            if (int.TryParse(losConst.Text, out var conValue)) character.Cons = conValue;

            AppCache.Characters.Add(character);
            AppCache.SyncEditors();

            this.Close();
        }

        private void losInt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void losChar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
