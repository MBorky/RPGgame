using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Eq
{
    internal class NoWeapon : Weapon
    {
        internal override string Name { get; }
        internal override int BaseDmg { get; }

        public NoWeapon()
        {
            Name = "No weapon";
            BaseDmg = 0;
        }
    }
}
