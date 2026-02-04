using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using examC;

namespace ToyGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ToyShop toyshop = new ToyShop("Pinoccio");

        public MainWindow()
        {
            InitializeComponent();
            AddData();
        }

        public void AddData()
        {
            Toy t1 = new Toy();
            t1.AddKind("creative");
            t1.AddKind("educational");

            Toy t2 = new Toy();
            t2.AddKind("creative");
            t2.AddKind("musical");
            t2.AddKind("wooden");

            Toy t3 = new Toy();
            t3.AddKind("wooden");

            toyshop.NewToy(t1);
            toyshop.NewToy(t2);
            toyshop.NewToy(t3);
            lbToys.ItemsSource = toyshop.Toys.Values;
            tbSuma.Text = $"${toyshop.TotalValueOfToys():F2}";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnKind_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)cbKind.SelectedItem;
            string addKind = item.Content.ToString();

            Toy toy = (Toy)lbToys.SelectedItem;
            toy.AddKind(addKind);
            lbToys.Items.Refresh();
            tbSuma.Text = $"${toyshop.TotalValueOfToys():F2}";
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            /*
            Toy toy = (Toy)lbToys.SelectedItem;
            toyshop.RemoveToy(toy.toyCode);
            lbToys.ItemsSource = null;
            lbToys.ItemsSource = toyshop.Toys.Values;
            */

            if (lbToys.SelectedItem is Toy selectedToy)
            {
                toyshop.RemoveToy(selectedToy.toyCode);

                lbToys.ItemsSource = null;
                lbToys.ItemsSource = toyshop.Toys.Values;

                tbSuma.Text = $"${toyshop.TotalValueOfToys():F2}";
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)cbKind.SelectedItem;
            string addKind = item.Content.ToString();

            lbSelect.ItemsSource = toyshop.SelectToys(addKind).ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Toy toy = new Toy();
            toyshop.NewToy(toy);
            lbToys.Items.Refresh();
            tbSuma.Text = $"${toyshop.TotalValueOfToys():F2}";
        }
    }
}