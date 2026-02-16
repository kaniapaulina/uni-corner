using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Races
{
    public class Dwarf:UnitRace
    {
        public Dwarf() : base() { }
        public override string RaceName => "Dwarf";
        public override void ApplyBonus(Unit unit)
        {
        }
    }
}
