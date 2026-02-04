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
using examB;

namespace Hotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Hotels hotel = new Hotels("Hotel PK");
        public MainWindow()
        {
            InitializeComponent();

            AddData();
            this.lbRooms.ItemsSource = hotel.Rooms;
        }

        public void AddData()
        {
            var r1 = new Room("economic");
            var r2 = new Room("luxury");

            hotel.RegisterRoom(r1);
            hotel.RegisterRoom(r2);

            hotel.RentRoom(r2.RoomNumber);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btnRent_Click(object sender, RoutedEventArgs e)
        {
            if (lbRooms.SelectedItem is Room room)
            {
                hotel.RentRoom(room.RoomNumber);
            }

            this.lbRooms.Items.Refresh();
            this.lbReservations.ItemsSource = hotel.RoomRents.Keys.ToList();

            this.tbGain.Text = $"Całkowity zysk {hotel.TotalGain():F2} zl";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbStandard.SelectedItem;

            string standard = selectedItem.Content.ToString();
            Room r = new Room(standard);
            hotel.RegisterRoom(r);

            this.lbRooms.Items.Refresh(); 
        }
    }
}