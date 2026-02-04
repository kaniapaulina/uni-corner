using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examB
{
    public enum EnumStandard
    {
        economic = 200,
        high_standard = 350,
        luxury = 400,
        superb = 699
    }

    public class Room
    {
        string roomNumber;
        bool available;
        EnumStandard standard;
        decimal roomPrice;
        static int roomCode;

        public string RoomNumber { get => roomNumber; private set => roomNumber = value; }
        public bool Available { get => available; private set => available = value; }

        static Room()
        {
            roomCode = 100;
        }
        public Room(string standard)
        {
            Available = true;
            Enum.TryParse(standard, out this.standard);

            RoomNumber = $"{standard.Substring(0, 2).ToUpper()}/{roomCode}/{DateTime.Now.ToString("yy")}";
            roomCode++;

            Random rand = new Random();
            decimal value = rand.Next(0, 100);
            this.roomPrice = (decimal)(int)this.standard + value;
        }

        public void ChangeAvailability()
        {
            if (Available == true)
                Available = false;
            else
                Available = true;

        }

        public decimal ShowPrice()
        {
            return roomPrice;
        }

        public override string ToString()
        {
            return $"{RoomNumber}, {standard}, {ShowPrice():F2} zł";
        }

    }
}
