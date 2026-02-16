using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Races
{
    public class Half_Elf:UnitRace
    {
        public Half_Elf() : base() { }
        public override string RaceName => "Elf";
        public override void ApplyBonus(Unit unit)
        {
            unit.Charm += 2;
        }
    }
}
