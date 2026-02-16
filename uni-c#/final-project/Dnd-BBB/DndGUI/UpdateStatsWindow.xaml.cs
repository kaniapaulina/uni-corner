using Dnd_BBB.Core;
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

namespace DndGUI
{
    /// <summary>
    /// Okno szybkiej modyfikacji bieżących statystyk (HP, Złoto, Poziom) wybranej postaci.
    /// </summary>
    public partial class UpdateStatsWindow : Window
    {
        public Character SelectedCharacter { get; private set; }

        public UpdateStatsWindow()
        {
            InitializeComponent();
        }
        public UpdateStatsWindow(Character character) : this()
        {
            SelectedCharacter = character;
            LoadValues();
        }

        private void LoadValues()
        {
            if (SelectedCharacter == null) return;
            txtHpDelta.Text = "0";
            txtLvlCount.Text = "1";
            txtAcDelta.Text = "0";
            txtGoldDelta.Text = "0";
        }


        private void BtnHpApply_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCharacter == null)
            {
                MessageBox.Show("Brak wybranej postaci.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtHpDelta.Text.Trim(), out int delta))
            {
                MessageBox.Show("Podaj poprawną liczbę punktów HP.", "Błąd danych", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (delta > 0)
                {
                    SelectedCharacter.HealDamage(delta);
                }
                else if (delta < 0)
                {
                    SelectedCharacter.TakeDamage(Math.Abs(delta));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zmiany HP: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void BtnLvlUp_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCharacter == null)
            {
                MessageBox.Show("Brak wybranej postaci.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtLvlCount.Text.Trim(), out int times) || times < 1)
            {
                MessageBox.Show("Podaj poprawną liczbę poziomów (>0).", "Błąd danych", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                for (int i = 0; i < times; i++)
                {
                    SelectedCharacter.OnLevelUp += (msg, lvl) => {
                        MessageBox.Show(msg, "Nowy Poziom!", MessageBoxButton.OK, MessageBoxImage.Information);
                    };
                    SelectedCharacter.LevelUp();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas poziomowania: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void BtnAcApply_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCharacter == null)
            {
                MessageBox.Show("Brak wybranej postaci.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtAcDelta.Text.Trim(), out int delta))
            {
                MessageBox.Show("Podaj poprawną wartość AC.", "Błąd danych", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                SelectedCharacter.Ac += delta;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zmiany AC: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void BtnGoldApply_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCharacter == null)
            {
                MessageBox.Show("Brak wybranej postaci.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtGoldDelta.Text.Trim(), out int delta))
            {
                MessageBox.Show("Podaj poprawną wartość złota.", "Błąd danych", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                int newGold = SelectedCharacter.Gold + delta;
                SelectedCharacter.Gold = newGold;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zmiany złota: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
