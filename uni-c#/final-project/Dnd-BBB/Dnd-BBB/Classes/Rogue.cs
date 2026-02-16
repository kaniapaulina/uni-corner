using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Classes
{
    public class Rogue : UnitClass
    {
        public Rogue() : base() { }
        public override string ClassName => "Rogue";
        public override int HitDie => 8;
        public override bool Spell => false;
        public override List<StatType> StatPrio => new List<StatType>
        {
            StatType.Dex, StatType.Intel, StatType.Str, StatType.Cons, StatType.Wis, StatType.Charm
        };
        public override void AssignStarterPack(Character c)
        {
            c.Equipment.Add("a rapier");
            c.Equipment.Add("a shortbow");
            c.Equipment.Add("a quiver of 20 arrows");
            c.Equipment.Add("a burglar’s pack");
            c.Equipment.Add("leather armor");
            c.Equipment.Add("two daggers");
            c.Equipment.Add("thieves’ tools");
        }
    }
}
