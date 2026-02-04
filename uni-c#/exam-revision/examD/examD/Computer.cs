using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace examD
{
    public enum EnumDriveType
    {
        SATA,
        SAS,
        NLSAS,
        SSD
    }

    public interface IPriceable
    {
        public decimal GetPrice();
    }

    public class Computer : IComparable<Computer>, IPriceable
    {
        static int counter;
        public DateTime productionDate;
        public EnumDriveType driveType;
        decimal drivePrice;
        public readonly string computerID;
        bool isOSInstalled; 
        
        static Computer()
        {
            counter = 1;
        }

        public Computer(string type)
        {
            productionDate = DateTime.Now;
            isOSInstalled = false;
            drivePrice = 500.0m;
            Enum.TryParse(type, out this.driveType);
            computerID = $"{type.Substring(0,3).ToUpper()}-{counter:D6}{DateTime.Now.ToString("dd/MM/yyyy")}";
            counter ++;
        }

        public string IsInstalled()
        {
            return (isOSInstalled == true ? "+" : "-");
        }

        public virtual decimal GetPrice()
        {
            decimal price = 1598.5m;
            price += drivePrice;
            if (isOSInstalled) price += 495.25m;
            return price;
        }

        public override string ToString()
        {
            return $"{computerID} {GetPrice():F2} PLN, OS[{IsInstalled()}]";
        }

        public int CompareTo(Computer? other)
        {
            return this.GetPrice().CompareTo(other.GetPrice());
        }
    }
}
