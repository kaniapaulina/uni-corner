using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Races
{
    public class Halfling:UnitRace
    {
        public Halfling() : base() { }
        public override string RaceName => "Halfling";
        public override void ApplyBonus(Unit unit)
        {
            unit.Dext += 2;
        }
    }
}
