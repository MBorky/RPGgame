using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Eq
{
    internal class HeavyArmor : Armor
    {
        internal override string Name { get; }
        internal override int BaseReduction { get; }
        internal HeavyArmor(int worldLevel)
        {
            if (worldLevel == 1)
            {
                Name = "Heavy Armor";
            }
            else
            {
                Name = $"Heavy Armor + {worldLevel}";
            }
            
            BaseReduction = 2 * worldLevel;
        }
    }
}
