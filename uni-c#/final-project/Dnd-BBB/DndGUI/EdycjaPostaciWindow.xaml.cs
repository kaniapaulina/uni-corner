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
using Dnd_BBB;
using Dnd_BBB.Core;
using Dnd_BBB.Classes;
using Dnd_BBB.Races;
using Dnd_BBB.Service;
using Dnd_BBB.Exceptions;


namespace DndGUI
{

    /// <summary>
    /// Panel zarządzania istniejącymi postaciami. Umożliwia edycję statystyk, 
    /// zarządzanie inwentarzem i wywoływanie mechanik awansu (LevelUp).
    /// </summary>
    public partial class EdycjaPostaciWindow : Window
    {

        public EdycjaPostaciWindow()
        {
            InitializeComponent();
            RefreshCharacters(AppCache.Characters);
        }

        public void RefreshCharacters(List<Character> list)
        {
            charactersComboBox.ItemsSource = null;
            charactersComboBox.ItemsSource = list;
            charactersComboBox.DisplayMemberPath = "Name";
        }

        private void charactersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (charactersComboBox.SelectedItem is not Character c) return;


            c.Proficiencies ??= new List<string>();
            c.Spells ??= new List<string>();
            c.Equipment ??= new List<string>();


            if (c.UnitClass != null && (c.Equipment == null || c.Equipment.Count == 0))
            {
                c.UnitClass.AssignStarterPack(c);
            }


            SetTextBoxOrLabel("txtClass", c.UnitClass?.ClassName ?? string.Empty);
            SetTextBoxOrLabel("txtRace", c.UnitRace?.RaceName ?? string.Empty);


            SetContentControl("badgeLvl", c.Level.ToString());
            SetContentControl("badgeHp", c.Hp.ToString());
            SetContentControl("badgeAc", c.Ac.ToString());
            SetContentControl("badgeGold", c.Gold.ToString());


            SetListViewItems("listViewProficiencies", c.Proficiencies);
            SetListViewItems("listViewSpells", c.Spells);
            SetListViewItems("listViewEquipment", c.Equipment);

            UpdateStatsAndModifiers(c);
        }

        private void UpdateStatsAndModifiers(Character c)
        {
            SetStatValueControl("lblDextValue", c.Dext);
            SetStatValueControl("lblIntValue", c.Intel);
            SetStatValueControl("lblStrValue", c.Str);
            SetStatValueControl("lblWisValue", c.Wis);
            SetStatValueControl("lblCharValue", c.Charm);
            SetStatValueControl("lblConsValue", c.Cons);

            int GetMod(int stat) => c.UnitClass?.Calc(stat) ?? (int)Math.Floor((stat - 10) / 2.0);

            SetBonusTextBox("txtDextBonus", GetMod(c.Dext));
            SetBonusTextBox("txtIntBonus", GetMod(c.Intel));
            SetBonusTextBox("txtStrBonus", GetMod(c.Str));
            SetBonusTextBox("txtWisBonus", GetMod(c.Wis));
            SetBonusTextBox("txtCharBonus", GetMod(c.Charm));
            SetBonusTextBox("txtConsBonus", GetMod(c.Cons));
            SetBonusTextBox("txtBonusUmiejetnosci", c.ProficiencyBonus);
        }


        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (charactersComboBox.SelectedItem is not Character c) return;

            try
            {
                int debugHp = GetValueFromControl("badgeHp");
                if (debugHp == 0)
                {
                    MessageBox.Show("Ostrzeżenie: Odczytano HP jako 0. Przerwanie zapisu, aby nie uszkodzić danych.");
                    return;
                }
                c.Hp = GetValueFromControl("badgeHp");
                c.Ac = GetValueFromControl("badgeAc");
                c.Gold = GetValueFromControl("badgeGold");

                int targetLvl = GetValueFromControl("badgeLvl");
                while (c.Level < targetLvl) c.LevelUp();

                var partyToSave = c.Party;
                if (c.Party != null)
                {
                    AppCache.SyncEditors();
                    partyToSave.SaveToDb(partyToSave);
                    MessageBox.Show("Zmiany zapisane pomyślnie!");
                }
                else
                {
                    MessageBox.Show("Błąd: Nie znaleziono przypisanej drużyny!");
                }
            }
            catch (Exception ex) { MessageBox.Show($"Błąd: {ex.Message}"); }
        }
        private int GetValueFromControl(string name)
        {
            var ctrl = this.FindName(name);
            if (ctrl == null) return 0;

            if (ctrl is HandyControl.Controls.Badge badge)
            {
                try
                {
                    return Convert.ToInt32(badge.Value);
                }
                catch
                {
                    return 0;
                }
            }
            if (ctrl is TextBox tb)
            {
                return int.TryParse(tb.Text, out int res) ? res : 0;
            }
            if (ctrl is ContentControl cc)
            {
                string contentStr = cc.Content?.ToString() ?? "0";
                return int.TryParse(contentStr, out int res) ? res : 0;
            }
            return 0;
        }

        private void AddSpell_Click(object sender, RoutedEventArgs e) => AddToList("txtNewSpell", "listViewSpells", (c, v) => c.AddSpell(v));
        private void RemoveSpell_Click(object sender, RoutedEventArgs e) => RemoveFromList("listViewSpells", (c, v) => c.Spells.Remove(v));
        private void AddEquipment_Click(object sender, RoutedEventArgs e) => AddToList("txtNewEquip", "listViewEquipment", (c, v) => c.Equipment.Add(v));
        private void RemoveEquipment_Click(object sender, RoutedEventArgs e) => RemoveFromList("listViewEquipment", (c, v) => c.Equipment.Remove(v));

        private void AddToList(string txtName, string lvName, Action<Character, string> action)
        {
            if (charactersComboBox.SelectedItem is not Character c) return;
            var tb = this.FindName(txtName) as TextBox;
            if (string.IsNullOrWhiteSpace(tb?.Text)) return;
            try { action(c, tb.Text); SetListViewItems(lvName, GetListSource(lvName, c)); tb.Clear(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void RemoveFromList(string lvName, Func<Character, string, bool> action)
        {
            if (charactersComboBox.SelectedItem is not Character c) return;
            var lv = this.FindName(lvName) as ListView;
            if (lv?.SelectedItem is string s && action(c, s)) SetListViewItems(lvName, GetListSource(lvName, c));
        }

        private IEnumerable<string> GetListSource(string lvName, Character c) => lvName.Contains("Spell") ? c.Spells : c.Equipment;


        private void SetTextBoxOrLabel(string name, string text)
        {
            var ctrl = this.FindName(name);
            if (ctrl is TextBox tb) tb.Text = text;
            else if (ctrl is Label lbl) lbl.Content = text;
            else if (ctrl is ContentControl cc) cc.Content = text;
        }

        private void SetContentControl(string name, string text)
        {
            var ctrl = this.FindName(name);
            if (ctrl == null) return;


            var valueProp = ctrl.GetType().GetProperty("Value");
            if (valueProp != null && valueProp.CanWrite)
            {
                try
                {
                    var targetType = valueProp.PropertyType;
                    object converted;
                    if (targetType == typeof(string))
                    {
                        converted = text;
                    }
                    else
                    {
                        converted = Convert.ChangeType(text, targetType);
                    }

                    valueProp.SetValue(ctrl, converted);
                    return;
                }
                catch
                {

                }
            }


            if (ctrl is ContentControl cc) cc.Content = text;
        }

        private void SetListViewItems(string name, IEnumerable<string> items)
        {
            var lv = this.FindName(name) as ListView;
            if (lv == null) return;


            if (lv.ItemsSource != null)
                lv.ItemsSource = null;


            if (lv.Items.Count > 0)
                lv.Items.Clear();

            lv.ItemsSource = items ?? new List<string>();
        }

        private void SetStatValueControl(string controlName, int value)
        {
            var ctrl = this.FindName(controlName);
            if (ctrl is ContentControl cc) cc.Content = value.ToString();
            else if (ctrl is TextBox tb) tb.Text = value.ToString();
            else if (ctrl is Label lbl) lbl.Content = value.ToString();
        }


        private void SetBonusTextBox(string controlName, int modifier)
        {
            var ctrl = this.FindName(controlName) as TextBox;
            if (ctrl == null) return;
            ctrl.Text = modifier >= 0 ? $"+{modifier}" : modifier.ToString();
        }

        // Przywrócony przycisk "Zmień statystyki" — otwiera okno UpdateStatsWindow.
        // Jeśli wybrana jest postać, przekazujemy ją do okna; po zamknięciu odświeżamy widok.
        private void ZmianaStatsButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = charactersComboBox.SelectedItem as Character;
            var wnd = (selected != null) ? new UpdateStatsWindow(selected) : new UpdateStatsWindow();
            wnd.Owner = this;
            wnd.ShowDialog();
            if (selected != null) charactersComboBox_SelectionChanged(null, null);
        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}

