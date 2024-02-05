using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Eq
{
    internal class Axe : Weapon
    {

        internal override string Name { get; }
        internal override int BaseDmg { get; }

        public Axe(int worldLevel)
        {
            if (worldLevel == 1)
            {
                Name = "Axe";
            }
            else
            {
                Name = $"Axe + {worldLevel}";
            }

            BaseDmg = 2 * worldLevel;
        }
    }
}
