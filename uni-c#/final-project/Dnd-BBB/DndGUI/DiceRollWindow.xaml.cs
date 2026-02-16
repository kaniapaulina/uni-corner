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
    /// Logika interakcji dla klasy DiceRollWindow.xaml
    /// </summary>
    public partial class DiceRollWindow : Window
    {
        public DiceRollWindow()
        {
            InitializeComponent();
            CloseAfterDelay();
        }

        private async void CloseAfterDelay()
        {
            await Task.Delay(2000);
            this.Close();
        }
    }
}
