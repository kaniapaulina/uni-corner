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
using examD;

namespace ComputerShopGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ComputerShop shop = new ComputerShop("Sklep AGD");
        
        public MainWindow()
        {
            InitializeComponent();
            AddData();
        }

        public void AddData()
        {
            tbName.Text = shop.Name;

            Computer c1 = new Computer("SAS");
            Computer c2 = new Computer("SSD");
            Computer c3 = new PersonalComputer("SAS", true);

            shop.AddComputer(c1);
            shop.AddComputer(c2);
            shop.AddComputer(c3);

            lbComp.ItemsSource = shop.Computers.ToList();

            tbSum.Text = $"{shop.TotalValue():F2} PLN";
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            shop.Computers.Sort();
            lbComp.ItemsSource = shop.Computers;
        }

        private void btnFInd_Click(object sender, RoutedEventArgs e)
        {
            if(cbEnum.SelectedItem is ComboBoxItem cb)
            {
                string select = cb.Content.ToString();

                lbComp.ItemsSource = null;
                lbComp.ItemsSource = shop.SelectByDrive(select);
            }

            
        }
    }
}