using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Races
{
    public class Dragonborn:UnitRace
    {
        public Dragonborn() : base() { }
        public override string RaceName => "Dragonborn";
        public override void ApplyBonus(Unit unit)
        {
            unit.Str += 2;
            unit.Charm += 1;
        }
    }
}
