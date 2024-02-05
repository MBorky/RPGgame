using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Eq
{ 
    internal class NoArmor : Armor
    {
        internal override string Name { get; }
        internal override int BaseReduction { get; }
        internal NoArmor()  
        {
            Name = "No Armor";
            BaseReduction = 0;
        }
    }
}
