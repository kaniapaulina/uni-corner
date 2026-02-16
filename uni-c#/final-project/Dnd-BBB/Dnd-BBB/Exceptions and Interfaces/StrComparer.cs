using Dnd_BBB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_BBB.Exceptions
{
    public class StrComparer : IComparer<Character>
    {
        public int Compare(Character? x, Character? y) => x.Str.CompareTo(y.Str);
        /*
        {
            throw new NotImplementedException();
        }
        */
    }
}
