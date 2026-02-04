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
using examF;

namespace CarshopGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RentalCompany rc = new RentalCompany();
        public MainWindow()
        {
            InitializeComponent();
            AddData();
            CountIncome();
        }

        public void AddData()
        {

            Vehicle v1 = new Vehicle();

            Car v2 = new Car();
            v2.hasGPS = true;

            Truck v3 = new Truck();
            v3.maxPayload = 1250;

            rc.AddVehicle(v1);
            rc.AddVehicle(v2);
            rc.AddVehicle(v3);

            lbVehicles.ItemsSource = rc.transport.Values;
        }

        public void CountIncome()
        {
            decimal totalincome = 0;
            foreach (Vehicle v in lbVehicles.Items)
            {
                totalincome += v.CalculateRentalPrice();
            }

            tbNapis.Text = $"Paulinas Rental Shop, Total Income: {totalincome:F2} PLN";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(cbType.SelectedItem is ComboBoxItem select)
            {
                string which = select.Content.ToString();
                if(which == "Car")
                {
                    Car car = new Car();
                    rc.AddVehicle(car);
                }
                else if(which == "Truck")
                {
                    Truck truck = new Truck();
                    rc.AddVehicle(truck);
                }
                lbVehicles.ItemsSource = null;
                lbVehicles.ItemsSource = rc.transport.Values;
                CountIncome();
            }
        }

        private void btnToggle_Click(object sender, RoutedEventArgs e)
        {
            if(lbVehicles.SelectedItem is Vehicle v)
            {
                if(v.isRented == true)
                {
                    v.isRented = false;
                }
                else
                {
                    v.isRented = true;
                }

                lbVehicles.Items.Refresh();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBest_Click(object sender, RoutedEventArgs e)
        {
            lbVehicles.ItemsSource = null;
            lbVehicles.ItemsSource = rc.GetTopPremiumVehicles();
        }
    }
}