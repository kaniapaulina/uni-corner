using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Classes
{
    public class Sorcerer : UnitClass
    {
        public Sorcerer() : base() { }
        public override string ClassName => "Sorcerer";
        public override int HitDie => 6;
        public override bool Spell => true;
        public override List<StatType> StatPrio => new List<StatType>
        {
            StatType.Charm, StatType.Dex, StatType.Cons, StatType.Intel, StatType.Wis, StatType.Str
        };
        public override void AssignStarterPack(Character c)
        {
            c.Equipment.Add("a light crossbow and 20 bolts");
            c.Equipment.Add("a component pouch");
            c.Equipment.Add("a dungeoneer’s pack");
            c.Equipment.Add("two daggers");
        }
    }
}
