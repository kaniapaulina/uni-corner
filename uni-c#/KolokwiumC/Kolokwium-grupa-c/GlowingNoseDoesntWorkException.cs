using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium_grupa_c
{
    internal class GlowingNoseDoesntWorkException : Exception
    {
        public GlowingNoseDoesntWorkException(string? message) : base(message)
        {
        }
    }
}
