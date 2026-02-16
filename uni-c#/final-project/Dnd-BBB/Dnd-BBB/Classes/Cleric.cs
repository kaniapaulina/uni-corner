using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Classes
{
    public class Cleric : UnitClass
    {
        public Cleric() : base() { }
        public override string ClassName => "Cleric";
        public override int HitDie => 8;
        public override bool Spell => true;
        public override List<StatType> StatPrio => new List<StatType>
        {
            StatType.Wis, StatType.Cons, StatType.Dex, StatType.Str, StatType.Intel, StatType.Charm
        };

        public override void AssignStarterPack(Character c)
        {
            c.Equipment.Add("a mace");
            c.Equipment.Add("leather armor");
            c.Equipment.Add("a light crossbow and 20 bolts");
            c.Equipment.Add("a priest’s pack");
            c.Equipment.Add("a shield");
            c.Equipment.Add("a holy symbol");
        }
    }
}
