using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examD
{
    public class ComputerShop
    {
        string name;
        List<Computer> computers;
        public string Name { get => name; set => name = value; }
        public List<Computer> Computers { get => computers; set => computers = value; }

        public ComputerShop(string name)
        {
            Name = name;
            Computers = new List<Computer>();
        }

        public void AddComputer(Computer c)
        {
            Computers.Add(c);
        }

        public void RemoveComputer(string cID)
        {
            Computers.RemoveAll(x => x.computerID == cID);
            // albo z: Computer toRemove = computers.Find(x => x.ComputerID == cID);
        }

        public decimal TotalValue()
        {
            decimal sum = 0;
            foreach (Computer c in Computers)
            {
                sum += c.GetPrice();
            }
            return sum;
        }
        public IEnumerable<Computer> SelectByDrive(string type)
        {
            List<Computer> listCom = new List<Computer>();
            EnumDriveType dt;
            Enum.TryParse(type, out dt);
            foreach (Computer c in Computers)
            {
                if (c.driveType == dt) listCom.Add(c);
            }

            return listCom;
        }

        public override string ToString()
        {
            return $"{Name}, {string.Join(",",Computers.ToString())}";
        }
    }
}