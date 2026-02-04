using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examB
{
    public class Hotels
    {
        string name;
        List<Room> rooms;
        Dictionary<string, decimal> roomRents;

        public string Name { get => name; private set => name = value; }
        public List<Room> Rooms { get => rooms; private set => rooms = value; }
        public Dictionary<string, decimal> RoomRents { get => roomRents; private set => roomRents = value; }

        public Hotels(string name)
        {
            Name = name;
            Rooms = new List<Room>();
            RoomRents = new Dictionary<string, decimal>();
        }

        public void RegisterRoom(Room room)
        {
            rooms.Add(room);
        }

        public Room? FindRoom(string roomNumber)
        {
            return rooms.Find(room => room.RoomNumber == roomNumber);
        }

        public void RentRoom(string roomNumber)
        {
            var room = FindRoom(roomNumber);
            if (room is null)
                return;

            if (room.Available == false)
                return;

            string klucz = $"{room.ToString()}, rent date: {DateTime.Now.ToString("dd-MM-yy")}";
            decimal wartosc = room.ShowPrice();
            RoomRents.Add(klucz, wartosc);

            room.ChangeAvailability();
        }

        public decimal TotalGain()
        {
            var gain = 0.0m;
            foreach (var room in RoomRents)
            {
                gain += room.Value;
            }
            return gain;
        }
    }
}
