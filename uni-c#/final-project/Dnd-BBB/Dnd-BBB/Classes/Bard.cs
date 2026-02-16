using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Classes
{
    public class Bard : UnitClass
    {
        public Bard() : base() { }
        public override string ClassName => "Bard";
        public override int HitDie => 8;
        public override bool Spell => true;
        public override List<StatType> StatPrio => new List<StatType>
        {
            StatType.Charm, StatType.Dex,  StatType.Cons, StatType.Intel, StatType.Wis, StatType.Str
        };
        public override void AssignStarterPack(Character c)
        {
            c.Equipment.Add("a rapier");
            c.Equipment.Add("an entertainer’s pack");
            c.Equipment.Add("a lute");
            c.Equipment.Add("leather armor");
            c.Equipment.Add("a dagger");
        }
    }
}
