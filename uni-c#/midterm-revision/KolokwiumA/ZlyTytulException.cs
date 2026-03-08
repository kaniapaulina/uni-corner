using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumA
{
    internal class ZlyTytulException:Exception
    {
        public ZlyTytulException(string message) : base(message)
        {
        }
    }
}
