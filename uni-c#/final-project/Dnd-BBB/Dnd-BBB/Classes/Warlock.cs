using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Classes
{
    public class Warlock : UnitClass
    {
        public Warlock() : base() { }
        public override string ClassName => "Warlock";
        public override int HitDie => 8;
        public override bool Spell => true;
        public override List<StatType> StatPrio => new List<StatType>
        {
            StatType.Charm, StatType.Dex, StatType.Cons, StatType.Intel, StatType.Wis, StatType.Str
        };

        public override void AssignStarterPack(Character c)
        {
            c.Equipment.Add("a light crossbow and 20 bolts");
            c.Equipment.Add("a component pouch");
            c.Equipment.Add("a scholar’s pack");
            c.Equipment.Add("leather armor");
            c.Equipment.Add("handaxe");
            c.Equipment.Add("two daggers");
        }
    }
}
