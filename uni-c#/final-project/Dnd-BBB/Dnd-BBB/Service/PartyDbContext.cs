using Dnd_BBB.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_BBB.Service
{
    internal class PartyDbContext: DbContext
    {
        public DbSet<Party> Parties { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}
