using Dnd_BBB.Classes;
using Dnd_BBB.Core;
using Dnd_BBB.Races;
using Dnd_BBB.Service;

namespace Dnd_BBB
{
    public static class GlobalState
    {
        public static Party CurrentParty { get; set; } = new Party("Moja Drużyna");
        public static void RefreshFromDisk(string path)
        {
            var loaded = StorageService.ReadPartyJSON(path);
            if (loaded != null) CurrentParty = loaded;
        }
    }

    public enum StatType { Str, Dex, Intel, Wis, Charm, Cons }
    internal class Program
    {
        static void Main(string[] args)
        {
            UnitRace r1 = new Human();
            UnitClass c1 = new Bard();
            Character char1 = new Character("Paulina", c1, r1);
            char1.LevelUp();
            char1.LevelUp();

            UnitRace r2 = new Dragonborn();
            UnitClass c2 = new Sorcerer();
            Character char2 = new Character("Wiktoria", c2, r2);
            char2.AddSpell("Ray of Frost");
            char2.AddSpell("Acid Splash");
            char2.AddSpell("Burning Hands");
            char2.AddProficiencies("Deception", "Insight", "Arcana");


            UnitRace r3 = new Gnome();
            UnitClass c3 = new Ranger();
            Character char3 = new Character("Nates", c3, r3);
            char3.AddProficiencies("Survival", "Stealth", "Athletics");

            Party p1 = new Party("Magic nerds");
            p1.AddMember(char1);
            p1.AddMember(char2);
            p1.AddMember(char3);

            Console.WriteLine(p1);

            // TEST NA JSONA
            Console.WriteLine("======== TEST JSON");
            StorageService.SavePartyJSON("party.json", p1);

            Party odczyt = StorageService.ReadPartyJSON("party.json");
            Console.WriteLine(odczyt);
            p1.SaveToDb(p1);
        }
    }
}
