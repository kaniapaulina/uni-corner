using Dnd_BBB.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dnd_BBB.Service
{
    /// <summary>
    /// Klasa narzędziowa do obsługi trwałości danych. 
    /// Odpowiada za serializację i deserializację obiektu Party i Character
    /// do formatu JSON, wspierając polimorfizm klas i ras.
    /// </summary>
    public class StorageService
    {
        public static void SavePartyJSON(string nazwa, Party p)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
            string jsonString = JsonSerializer.Serialize(p, options);
            File.WriteAllText(nazwa, jsonString);
        }

        public static Party ReadPartyJSON(string nazwa)
        {
            if (!File.Exists(nazwa)) return null;
            string jsonString = File.ReadAllText(nazwa);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            return JsonSerializer.Deserialize<Party>(jsonString);
        }

        public static void SaveAllCharacters(List<Character> characters)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(characters, options);
            File.WriteAllText("all_characters.json", json);
        }

        public static List<Character> LoadAllCharacters()
        {
            if (!File.Exists("all_characters.json")) return new List<Character>();
            string json = File.ReadAllText("all_characters.json");
            return JsonSerializer.Deserialize<List<Character>>(json) ?? new List<Character>();
        }

    }
}
