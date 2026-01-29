using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumB
{
    public enum EnumOperatorSieci {TMobile, PlusGSM, Virgin, Orange}
    public class TelefonKomórkowy:Telefon
    {
        EnumOperatorSieci operatorSieci;
        static decimal oplataDodatkowa;

        public EnumOperatorSieci OperatorSieci { get => operatorSieci; set => operatorSieci = value; }
        public static decimal OplataDodatkowa { get => oplataDodatkowa; set => oplataDodatkowa = value; }

        static TelefonKomórkowy()
        {
            oplataDodatkowa = 0.05M;
        }

        public TelefonKomórkowy() : base()
        {

        }

        public TelefonKomórkowy(string numerTelefonu, Abonent wlasciciel, EnumOperatorSieci operatorSieci) : base(numerTelefonu, wlasciciel)
        {
            this.operatorSieci = operatorSieci;
        }

        public override decimal OplataZaRozmowe(float minuty)
        {
            return base.OplataZaRozmowe(minuty)+oplataDodatkowa*(decimal)minuty;
        }

        public override string ToString() 
        {
            return base.ToString() + $" {operatorSieci}";
        }
    }
}
