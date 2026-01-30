using EgzaminPróbny;
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

namespace BoardGameMenager.Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GamingClub club = new GamingClub();
        public MainWindow()
        {
            InitializeComponent();

            PrepareData();
        }

        private void PrepareData()
        {
            var player1 = new BoardGamePlayer("JanuszPlansz", "Catan");
            var player2 = new TournamentPlayer("ProGamerPL", "Chaos in the World", EnumLeague.Gold);
            var player3 = new TournamentPlayer("Amator123", "Monopoly", EnumLeague.Bronze);

            player1.AddScores(new double[] { 8.5, 9.0, 7.5, 10 });
            player2.AddScores(new double[] { 9.5, 8.0, 9.0, 10.0, 9.5 });
            player3.AddScores(new double[] { 2, 3 });

            club.AddMember(player1);
            club.AddMember(player2);
            club.AddMember(player3);

            this.ListBoxPlayers.ItemsSource = club.Members;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e) => this.Close();

        private void ListBoxPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.ListBoxPlayers.SelectedItem is BoardGamePlayer selectedPlayer)
            {
                tbNick.DataContext = selectedPlayer;

                var avg = selectedPlayer.CalculateAverageScore();
                TextBlockAvg.Text = avg.ToString("F2");

                var reward = selectedPlayer.CalculateReward();
                TextBlockReward.Text = reward.ToString("F2") + "PLN";
            }
            
        }
    }
}