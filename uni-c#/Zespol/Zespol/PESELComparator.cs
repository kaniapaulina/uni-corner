using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsobaZespol
{
    public class PESELComparator : IComparer<CzlonekZespolu>
    // IComparer jest uzywany jako argument w metodach sortujacych
    // IComparable jest implementowany bezposrednio w klasie
    {
        /*
        int IComparer<CzlonekZespolu>.Compare(CzlonekZespolu? x, CzlonekZespolu? y)
        {
            return x.Pesel.CompareTo(y.Pesel);
        }*/
        public int Compare(CzlonekZespolu? x, CzlonekZespolu? y)
        {
            return x.Pesel.CompareTo(y.Pesel);
        }
    }
}
