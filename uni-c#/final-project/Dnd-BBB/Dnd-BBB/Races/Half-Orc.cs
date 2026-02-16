using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Races
{
    public class Half_Orc:UnitRace
    {
        public Half_Orc() : base() { }
        public override string RaceName => "Half-Orc";
        public override void ApplyBonus(Unit unit)
        {
            unit.Hp += 1;
            unit.Ac += 1;
            unit.Str += 2;
        }
    }
}
