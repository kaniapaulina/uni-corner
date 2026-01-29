using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumB
{
    public class TelefonStacjonarny:Telefon
    {
        bool sekretarka;


        public TelefonStacjonarny(string numerTelefonu, Abonent wlasciciel, bool sekretarka) : base(numerTelefonu, wlasciciel)
        {
            this.sekretarka = sekretarka;
        }

        public override string ToString()
        {
            return base.ToString() + $"{(sekretarka ? ", [sekretarka+]" : "")}";
        }

        public bool Sekretarka { get => sekretarka; set => sekretarka = value; }
    }
}
