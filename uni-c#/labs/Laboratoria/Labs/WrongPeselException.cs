using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoria.Labs
{
    internal class WrongPeselException:Exception
    {
        public WrongPeselException(string message) : base(message)
        {

        }
    }
}
