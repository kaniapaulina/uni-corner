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

namespace examG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Airline airline = new Airline();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddFlight_Click(object sender, RoutedEventArgs e)
        {
            if(cbFlight.SelectedItem is ComboBoxItem wybor)
            {
                string rodzaj = wybor.Content.ToString();
                if (rodzaj == "Charter") 
                { 
                    CharterFlight flight = new CharterFlight("KRK");
                    airline.AddFlight(flight);
                }
                if(rodzaj == "Business")
                {
                    BusinessFlight flight = new BusinessFlight("KRK");
                    airline.AddFlight(flight);
                }
            }

            lbFlights.ItemsSource = null;
            lbFlights.ItemsSource = airline.flights;
        }

        private void btnAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            if(lbFlights.SelectedItem is Flight flight && tbPassenger.Text is string name)
            {
                airline.BookPassenger(flight.flightID, name);
                lbFlights.Items.Refresh();
            }
        }

        private void btnTopFlights_Click(object sender, RoutedEventArgs e)
        {
            lbTopFlights.ItemsSource = null;
            lbTopFlights.ItemsSource = airline.GetTopFlights();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}