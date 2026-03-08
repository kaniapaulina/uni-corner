using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium_grupa_c
{
    public class ReniferComparer : IComparer<ReniferPociagowy>
    {
        public int Compare(ReniferPociagowy? x, ReniferPociagowy? y)
        {
            if (x.Nazwisko.CompareTo(y.Nazwisko) == 0)
            {
                return x.NumerEwidencji.CompareTo(y.NumerEwidencji);
            }
            return x.Nazwisko.CompareTo(y.Nazwisko);
            //throw new NotImplementedException();
        }
    }
}
