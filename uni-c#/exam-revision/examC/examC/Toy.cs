using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examC
{
    public enum EnumToyKind
    {
        basic = 0,
        interactive = 100,
        creative = 80,
        educational = 120,
        musical = 60,
        wooden = 50
    }
    public class Toy:IComparable<Toy>
    {
        static long toyIndex;
        static decimal toyBasicPrice;
        public readonly string toyCode;
        private HashSet<EnumToyKind> toyKinds;

        static Toy()
        {
            toyIndex = 500;
            toyBasicPrice = 29.99m;
        }

        public Toy()
        {
            toyKinds = new HashSet<EnumToyKind>();
            toyCode = $"{toyIndex:D6}//{DateTime.Now.ToString("MM-yyyy")}";
            toyIndex++;
        }

        public IEnumerable<string> ToysKinds() 
        {
            //return toyKinds.Select(kind => kind.ToString());
            List<string> kind = new List<string>();
            foreach (var element in toyKinds)
            {
                kind.Add(element.ToString());
            }
            return kind;
        }

        public decimal ToyPrice()
        {
            decimal sum = 0; ;
            foreach (var element in toyKinds) 
            {
                sum += (decimal)element;
            }
            return (toyBasicPrice + sum);
        }

        public void AddKind(string toyKindStr)
        {
            EnumToyKind Str;
            Enum.TryParse(toyKindStr, out Str);
            toyKinds.Add(Str);
        }

        public int CompareTo(Toy? other)
        {
            if (other == null) return 1;

            int compare = this.toyKinds.Count.CompareTo(other.toyKinds.Count);
            if (compare != 0) return compare;
            return other.ToyPrice().CompareTo(this.ToyPrice());
        }

        public override string ToString()
        {
            return $"{toyCode}, ${ToyPrice():F2}, {{{string.Join(",", ToysKinds())}}}";
        }
    }
}
