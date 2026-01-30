using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgzaminPróbny
{
    public class BoardGamePlayer : IComparable<BoardGamePlayer>
    {
        private string nick;
        private string favGame;
        private string playerID;
        private List<double> scores;

        private static long counter;
        private static decimal basePrice;
        private static double qualifingAvg;

        public string Nick { get => nick; set => nick = value; }
        public string FavGame { get => favGame; set => favGame = value; }
        public string PlayerID { get => playerID; private set => playerID = value; } //private set
        public List<double> Scores { get => scores; } //brak setu
        public static long Counter { get => counter; set => counter = value; }
        public static decimal BasePrice { get => basePrice; set => basePrice = value; }
        public static double QualifingAvg { get => qualifingAvg; set => qualifingAvg = value; }

        static BoardGamePlayer()
        {
            counter = 10;
            basePrice = 250.0m; //m - decimal
            qualifingAvg = 7.5;
        }

        // Konstruktor albo z pól albo z właściowości
        public BoardGamePlayer(string nick, string favGame)
        {
            Nick = nick;
            FavGame = favGame;
            Counter++; //inkrementacja
            scores = new List<double>(); //tutaj albo przy ustawianiu listy u góry
            string year = DateTime.Now.ToString("yy"); //ostatnie dwie liczby roku
            PlayerID = $"P#{Counter}-{year}";
        }

        public void AddScores(double[] newScores)
        {
            if (newScores is null)
                return;

            if (newScores.Any(x => x < 0 || x > 10))
                throw new ArgumentOutOfRangeException("Scores must be between 0 and 10");

            scores.AddRange(newScores);
        }

        public double CalculateAverageScore()
        {
            if (scores.Count == 0 || scores is null) 
                return 0.0;

            return scores.Average();
            //return scores.Sum()/(double)scores.Count(); - inne rozwiazanie
        }

        public virtual decimal CalculateReward() //? - decimal moze też być nullem
        {
            double avg = CalculateAverageScore();

            if (avg > QualifingAvg)
                return BasePrice;

            return 0.0m;
        }

        public int CompareTo(BoardGamePlayer? other)
        {
            if(other is null) return 1;

            double thisAvg = this.CalculateAverageScore();
            double otherAvg = other.CalculateAverageScore();    

            return otherAvg.CompareTo(thisAvg); // malejaco
            // return thisAvg.CompareTo(otherAvg) * (-1)
            //throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Nick} ({FavGame}) [{PlayerID}] - Reward: {this.CalculateAverageScore():F2} PLN";
        }
    }
}
