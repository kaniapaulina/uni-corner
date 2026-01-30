using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoria.Labs
{
    internal interface IMagazynuje
    {
        void Umiesc(Paczka t);
        Paczka Pobierz();
        void Wyczysc();
        int PodajIlosc();
        Paczka PodajBiezacy();
    }
}
