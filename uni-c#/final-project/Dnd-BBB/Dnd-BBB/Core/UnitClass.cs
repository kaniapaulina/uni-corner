using Dnd_BBB.Classes;
using Dnd_BBB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Dnd_BBB.Core
{
    [JsonPolymorphic(IgnoreUnrecognizedTypeDiscriminators = true)]
    [JsonDerivedType(typeof(Barbarian), typeDiscriminator: "barbarian")]
    [JsonDerivedType(typeof(Bard), typeDiscriminator: "bard")]
    [JsonDerivedType(typeof(Cleric), typeDiscriminator: "cleric")]
    [JsonDerivedType(typeof(Druid), typeDiscriminator: "druid")]
    [JsonDerivedType(typeof(Fighter), typeDiscriminator: "fighter")]
    [JsonDerivedType(typeof(Monk), typeDiscriminator: "monk")]
    [JsonDerivedType(typeof(Paladin), typeDiscriminator: "paladin")]
    [JsonDerivedType(typeof(Ranger), typeDiscriminator: "ranger")]
    [JsonDerivedType(typeof(Rogue), typeDiscriminator: "rogue")]
    [JsonDerivedType(typeof(Sorcerer), typeDiscriminator: "sorcerer")]
    [JsonDerivedType(typeof(Warlock), typeDiscriminator: "warlock")]
    [JsonDerivedType(typeof(Wizard), typeDiscriminator: "wizard")]

    public abstract class UnitClass
    {
        protected UnitClass() { }
        public abstract string ClassName { get; }

        public abstract List<StatType> StatPrio { get; }

        public abstract int HitDie { get; }
        public virtual int BaseHp => HitDie;

        public abstract bool Spell { get;  }

        public virtual void AssignStats(Unit c) 
        {
            c.UnitRace.ApplyBonus(c);
            StatService service = new StatService();
            service.AssignWeightedStats(c);
            
            c.Hp += BaseHp;
            c.Hp += Calc(c.Cons);
            c.Ac += Calc(c.Dext);
        }

        public int Calc(int stat)
        {
            return (int)Math.Floor((stat - 10) / 2.0);
        }

        public virtual void AssignStarterPack(Character c){ }
    }

}
