using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Classes
{
    public class Barbarian : UnitClass
    {
        public Barbarian() : base() { }
        public override string ClassName => "Barbarian";
        public override int HitDie => 12;
        public override bool Spell => false;
        public override List<StatType> StatPrio => new List<StatType>
        {
            StatType.Str, StatType.Cons, StatType.Dex, StatType.Intel, StatType.Charm, StatType.Wis
        };

        public override void AssignStarterPack(Character c)
        {
            c.Equipment.Add("a greataxe");
            c.Equipment.Add("an explorer's pack");
            c.Equipment.Add("two handaxes");
        }

    }
}
