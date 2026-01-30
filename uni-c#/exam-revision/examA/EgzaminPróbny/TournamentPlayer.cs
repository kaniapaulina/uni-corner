using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgzaminPróbny
{

    public enum EnumLeague
    {
        Bronze,
        Silver,
        Gold
    }
    public class TournamentPlayer : BoardGamePlayer
    {
        private EnumLeague league;
        private static decimal bonusPrice;

        public EnumLeague League { get => league; set => league = value; }
        public static decimal BonusPrice { get => bonusPrice; set => bonusPrice = value; }

        public TournamentPlayer(string nick, string favGame, EnumLeague league) : base(nick, favGame)
        {
            League = league;
        }

        static TournamentPlayer()
        {
            BonusPrice = 500.00m;
        }

        public override decimal CalculateReward()
        {
             decimal basereward = base.CalculateReward();
            if (this.Scores.Count >= 5)
                return basereward + BonusPrice;
            return basereward;
        }

        public override string ToString()
        {
            return $"TP: {Nick} ({FavGame}) [{PlayerID}] - Reward: {this.CalculateAverageScore():F2} PLN {this.League}";
        }

    }
}
