using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examC
{
    public class ToyShop
    {
        string name;
        Dictionary<string, Toy> toys;

        public string Name { get => name; set => name = value; }
        public Dictionary<string, Toy> Toys { get => toys; set => toys = value; }

        public ToyShop(string name)
        {
            Name = name;
            Toys = new Dictionary<string, Toy>();
        }

        public void NewToy(Toy toy)
        {
            string klucz = toy.toyCode;
            Toys.Add(klucz, toy);
        }

        public void RemoveToy(string toyCode)
        {
            Toys.Remove(toyCode);
        }

        public decimal TotalValueOfToys()
        {
            decimal sum = 0;
            foreach (var element in Toys)
            {
                sum += element.Value.ToyPrice();
            }
            return sum;
        }

        public IEnumerable<Toy> SelectToys(string toyKind)
        {
            EnumToyKind kind;
            Enum.TryParse(toyKind, out kind);
            List<Toy> allKinds = new List<Toy>();
            foreach (var element in Toys.Values)
            {
                if(element.ToysKinds().Contains(kind.ToString()))
                {
                    allKinds.Add(element);
                }
            }
            return allKinds;
        }
    }
}
