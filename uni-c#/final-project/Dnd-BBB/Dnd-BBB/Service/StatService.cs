using Dnd_BBB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_BBB.Service
{
    /// <summary>
    /// Statyczny serwis odpowiedzialny za algorytmy generowania statystyk.
    /// Implementuje mechanikę rzutu 4k6 (drop lowest) oraz 
    /// inteligentne przypisywanie wyników zgodnie z priorytetami klasy.
    /// </summary>
    public class StatService
    {
        public void AssignWeightedStats(Unit unit)
        {
            Random rand = new Random();
            List<int> rolledValues = new List<int>();

            for (int i = 0; i < 6; i++)
            {
                rolledValues.Add(RollSingleStat(rand));
            }
            rolledValues = rolledValues.OrderByDescending(x => x).ToList();

            var priorities = unit.UnitClass.StatPrio;
            for (int i = 0; i < priorities.Count; i++)
            {
                int index = 0;
                if (rolledValues.Count > 1 && rand.Next(0, 100) > 90) //90%
                {
                    index = 1;
                }
                int finalValue = rolledValues[index];
                StatType currentStat = priorities[i];
                ApplyStatToUnit(unit, currentStat, finalValue);
                rolledValues.RemoveAt(index);
            }
        }

        private int RollSingleStat(Random rand)
        {
            List<int> rolls = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                rolls.Add(rand.Next(1, 7)); // rzut k6
            }
            return rolls.OrderBy(x => x).Skip(1).Sum();
        }

        private void ApplyStatToUnit(Unit unit, StatType statType, int value)
        {
            switch (statType)
            {
                case StatType.Str: unit.Str += value; break;
                case StatType.Dex: unit.Dext += value; break;
                case StatType.Intel: unit.Intel += value; break;
                case StatType.Wis: unit.Wis += value; break;
                case StatType.Charm: unit.Charm += value; break;
                case StatType.Cons: unit.Cons += value; break;
            }
        }
    }
}
