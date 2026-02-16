using Dnd_BBB.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dnd_BBB.Core
{
    [JsonPolymorphic(IgnoreUnrecognizedTypeDiscriminators = true)]

    [JsonDerivedType(typeof(Dragonborn), typeDiscriminator: "dragonborn")]
    [JsonDerivedType(typeof(Dwarf), typeDiscriminator: "dwarf")]
    [JsonDerivedType(typeof(Elf), typeDiscriminator: "elf")]
    [JsonDerivedType(typeof(Gnome), typeDiscriminator: "gnome")]
    [JsonDerivedType(typeof(Half_Elf), typeDiscriminator: "half_elf")]
    [JsonDerivedType(typeof(Halfling), typeDiscriminator: "halfling")]
    [JsonDerivedType(typeof(Half_Orc), typeDiscriminator: "half_orc")]
    [JsonDerivedType(typeof(Human), typeDiscriminator: "human")]
    [JsonDerivedType(typeof(Tiefling), typeDiscriminator: "tiefling")]

    public abstract class UnitRace
    {
        protected UnitRace() { }
        public abstract string RaceName { get; }
        public virtual void ApplyBonus(Unit unit) { }
    }
}
