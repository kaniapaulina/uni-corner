using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Classes
{
    public class Ranger : UnitClass
    {
        public Ranger() : base() { }
        public override string ClassName => "Ranger";
        public override int HitDie => 10;
        public override bool Spell => true;
        public override List<StatType> StatPrio => new List<StatType>
        {
            StatType.Dex, StatType.Cons, StatType.Wis, StatType.Intel, StatType.Str, StatType.Charm
        };
        public override void AssignStarterPack(Character c)
        {
            c.Equipment.Add("scale mail");
            c.Equipment.Add("two shortswords");
            c.Equipment.Add("a dungeoneer’s pack");
            c.Equipment.Add("a longbow");
            c.Equipment.Add("a quiver of 20 arrows");
        }
    }
}
