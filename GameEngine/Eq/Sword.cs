using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Eq
{
    internal class Sword : Weapon
    {
        internal override string Name { get; }
        internal override int BaseDmg { get; }

        public Sword(int worldLevel)
        {
            if (worldLevel == 1)
            {
                Name = "Sword";
            }
            else
            {
                Name = $"Sword + {worldLevel}";
            }

            BaseDmg = 2 * worldLevel;
        }
    }
}
