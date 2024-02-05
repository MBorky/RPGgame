using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Eq
{
    internal class LightArmor : Armor
    {
        internal override string Name { get; }
        internal override int BaseReduction { get; }
        internal LightArmor(int worldLevel)
        {
            if (worldLevel == 1)
            {
                Name = "Light Armor";
            }
            else
            {
                Name = $"Light Armor + {worldLevel}";
            }

            BaseReduction = worldLevel;
        }
    }
}
