using Dnd_BBB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_BBB.Exceptions
{
    public class HpComparer : IComparer<Character>
    {
        public int Compare(Character? x, Character? y) => x.Hp.CompareTo(y.Hp);
        /*
        {
            throw new NotImplementedException();
        }
        */
    }
}
