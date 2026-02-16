using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Classes
{
    public class Fighter : UnitClass
    {
        public Fighter() : base() { }
        public override string ClassName => "Fighter";
        public override int HitDie => 10;
        public override bool Spell => false;
        public override List<StatType> StatPrio => new List<StatType>
        {
            StatType.Str, StatType.Dex, StatType.Cons, StatType.Intel, StatType.Wis, StatType.Charm
        };

        public override void AssignStarterPack(Character c)
        {
            c.Equipment.Add("chain mail");
            c.Equipment.Add("a longsword");
            c.Equipment.Add("a shield");
            c.Equipment.Add("two handaxes");
            c.Equipment.Add("a dungeoneer's pack");
        }
    }
}
