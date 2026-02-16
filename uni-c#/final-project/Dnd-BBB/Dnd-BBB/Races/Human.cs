using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Races
{
    public class Human:UnitRace
    {
        public Human() : base() { }
        public override string RaceName => "Human";
        public override void ApplyBonus(Unit unit)  
        {
            unit.Hp += 1;
            unit.Ac += 1;
            unit.Dext += 1;
            unit.Str += 1;
            unit.Wis += 1;
            unit.Intel += 1;
            unit.Charm += 1;
        }
    }
} 
