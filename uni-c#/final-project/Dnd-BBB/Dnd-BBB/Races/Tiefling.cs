using Dnd_BBB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dnd_BBB.Races
{
    public class Tiefling:UnitRace
    {
        public Tiefling() : base() { }
        public override string RaceName => "Tiefling";
        public override void ApplyBonus(Unit unit)
        { 
            unit.Intel += 1;
            unit.Charm += 2;
        }
    }
}
