using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Eq
{
    public abstract class Weapon
    {
        internal abstract string Name { get; }
        internal abstract int BaseDmg { get; }
    }
}
