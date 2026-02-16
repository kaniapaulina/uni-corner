using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnd_BBB.Core;

namespace Dnd_BBB.Exceptions
{
    public class DextComparer : IComparer<Character>
    {
        public int Compare(Character? x, Character? y) => x.Dext.CompareTo(y.Dext);
        /*
        {
            throw new NotImplementedException();
        }
        */
    }
}
