using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgzaminPróbny
{
    public class GamingClub
    {
        private List<BoardGamePlayer> members;
        public List<BoardGamePlayer> Members { get => members; set => members = value; }

        public GamingClub() 
        { 
            Members = new List<BoardGamePlayer>();
        }

        public void AddMember(BoardGamePlayer player)
        {
            if (player is null)
                return;
            members.Add(player);
        }
    }
}
