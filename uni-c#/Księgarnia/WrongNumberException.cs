using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Księgarnia
{
    internal class wrongNumberException: Exception
    {
        public wrongNumberException(string message) : base(message)
        {
            Console.WriteLine("WrongNumberException: " + message);
        }
    }
}
