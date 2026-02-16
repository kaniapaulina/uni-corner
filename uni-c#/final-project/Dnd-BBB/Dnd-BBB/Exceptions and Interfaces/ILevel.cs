using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_BBB.Exceptions
{
    public interface ILevel
    {
        int Level { get; }
        void LevelUp();
    }
}
