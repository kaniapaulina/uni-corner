using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Classes
{
    public class Monk : UnitClass
    {
        public Monk() : base() { }
        public override string ClassName => "Monk";
        public override int HitDie => 8;
        public override bool Spell => false;
        public override List<StatType> StatPrio => new List<StatType>
        {
            StatType.Dex, StatType.Wis, StatType.Cons, StatType.Intel, StatType.Charm, StatType.Str
        };
        public override void AssignStarterPack(Character c)
        {
            c.Equipment.Add("a shortsword");
            c.Equipment.Add("a dungeoneer’s pack");
            c.Equipment.Add("10 darts");
        }
    }
}
