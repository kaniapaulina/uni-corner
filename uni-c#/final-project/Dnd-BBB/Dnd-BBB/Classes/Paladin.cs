using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Classes
{
    public class Paladin : UnitClass
    {
        public Paladin() : base() { }
        public override string ClassName => "Paladin";
        public override int HitDie => 10;
        public override bool Spell => true;
        public override List<StatType> StatPrio => new List<StatType>
        {
            StatType.Str, StatType.Dex, StatType.Cons, StatType.Charm, StatType.Wis, StatType.Intel
        };
        public override void AssignStarterPack(Character c)
        {
            c.Equipment.Add("a scimitar and a shield");
            c.Equipment.Add("five javelins");
            c.Equipment.Add("an explorer’s pack");
            c.Equipment.Add("chain mail");
            c.Equipment.Add("a holy symbol");
        }
    }
}
