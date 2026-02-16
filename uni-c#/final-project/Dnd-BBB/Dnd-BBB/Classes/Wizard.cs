using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Classes
{
    public class Wizard : UnitClass
    {
        public Wizard() : base() { }
        public override string ClassName => "Wizard";
        public override int HitDie => 6;
        public override bool Spell => true;
        public override List<StatType> StatPrio => new List<StatType>
        {
            StatType.Intel, StatType.Dex, StatType.Cons, StatType.Charm, StatType.Wis, StatType.Str
        };

        public override void AssignStarterPack(Character c)
        {
            c.Equipment.Add("a quarterstaff");
            c.Equipment.Add("a component pouch");
            c.Equipment.Add("a scholar’s pack");
            c.Equipment.Add("a spellbook");
        }
    }
}
