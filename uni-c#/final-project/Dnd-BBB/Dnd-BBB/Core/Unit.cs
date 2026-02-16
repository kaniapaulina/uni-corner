 using Dnd_BBB.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace Dnd_BBB.Core
{
    /// <summary>
    /// Klasa bazowa dla wszystkich jednostek w grze. 
    /// Przechowuje podstawowe statystyki (HP, AC, atrybuty) oraz 
    /// implementuje mechaniki walki (TakeDamage) i poziomu (LevelUp).
    /// </summary>
    public abstract class Unit : ILevel, IAction
    {
        private int hp; //Hitpoints
        private int ac; //Armor Class
        private int cons; //Constitution

        private int dext; //Dexterity
        private int str; //Strength
        private int wis; //Wisdom 
        private int intel; //Intelligence
        private int charm; //Charm

        //private UnitRace unitrace;
        //private UnitClass unitclass;

        /// <summary>
        /// Full Properties for each base stat, throwing InvalidStatValueException if stat reaches impossible value
        /// </summary>
        public int Hp { get => hp; 
            set 
            { 
                if( value > 640)
                {
                    throw new InvalidStatValueException("Impossible Hitpoints Value");
                }
                hp = value;
            } 
        }
        public int Ac
        {
            get => ac;
            set
            {
                if (value > 50)
                {
                    throw new InvalidStatValueException("Impossible Armor Class Value");
                }
                ac = value;
            }
        }

        public int Cons
        {
            get => cons;
            set
            {
                if (value > 50)
                {
                    throw new InvalidStatValueException("Impossible Constitution Value");
                }
                cons = value;
            }
        }

        public int Dext { get => dext;
            set
            {
                if (value < 0 || value > 30)
                {
                    throw new InvalidStatValueException("Impossible Dexterity Value");
                }
                dext = value;
            }
        }
        public int Str { get => str;
            set
            {
                if (value < 0 || value > 30)
                {
                    throw new InvalidStatValueException("Impossible Strength Value");
                }
                str = value;
            }
        }
        public int Wis { get => wis;
            set
            {
                if (value < 0 || value > 30)
                {
                    throw new InvalidStatValueException("Impossible Wisdom Value");
                }
                wis = value;
            }
        }
        public int Intel { get => intel;
            set
            {
                if (value < 0 || value > 30)
                {
                    throw new InvalidStatValueException("Impossible Intelligence Value");
                }
                intel = value;
            }
        }
        public int Charm { get => charm;
            set
            {
                if (value < 0 || value > 30)
                {
                    throw new InvalidStatValueException("Impossible Charm Value");
                }
                charm = value;
            }
        }


        // unitRace i unitClass jako stringi sa zapisywane w bazie danych, same obiekty nie sa mapowane
        [NotMapped]
        private UnitRace _unitRace;
        [NotMapped]
        public UnitRace UnitRace
        {
            get => _unitRace;
            set
            {
                _unitRace = value;
                UnitRaceName = value?.RaceName;
            }
        }

        [NotMapped]
        private UnitClass _unitClass;
        [NotMapped]
        public UnitClass UnitClass
        {
            get => _unitClass;
            set
            {
                _unitClass = value;
                UnitClassName = value?.ClassName;
            }
        }

        public string UnitRaceName { get; set; }
        public string UnitClassName { get; set; }

        public int ProficiencyBonus
        {
            get
            {
                if (Level < 5) return 2;
                if (Level < 9) return 3;
                if (Level < 13) return 4;
                if (Level < 17) return 5;
                return 6;
            }
        }

        public int Level
        {
            get;
            set;
        }

        public bool LifeStatus => (Hp <= 0); //gdy hp mniejsze lub rowne zero

        protected Unit()
        {
            this.hp = 0;
            this.ac = 10;
            this.cons = 0;

            this.dext = 0;
            this.str = 0;
            this.wis = 0;
            this.intel = 0;
            this.charm = 0;

            Level = 1;
        }

        public virtual void LevelUp()
        {
            Random rand = new Random();
            int maxroll = UnitClass.HitDie;
            int roll = rand.Next(1, maxroll + 1);

            int hpGain = roll + UnitClass.Calc(Cons);
            Hp += hpGain;
            Level++;
        }
        public void TakeDamage(int damage)
        {

            if (LifeStatus) return;
            Hp -= damage;
            if (Hp <= 0)
            {
                Hp = 0;
                DeathScreen(damage);
            }
        }
        protected virtual void DeathScreen(int damage)
        {
            Console.Write("this unit has died in an epic battle\n");
        }

        public void HealDamage(int heal)
        {
            if(LifeStatus) return;
            Hp += heal;
        }
    }
}
