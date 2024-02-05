using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Eq
{
    public abstract class Armor
    {
        internal abstract string?  Name { get; }
        internal abstract int BaseReduction { get; }
    }
}
