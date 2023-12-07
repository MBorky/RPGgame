using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    internal sealed class Warrior : Humanoid
    {
        internal Warrior(int level, string name, Statistics stats, int healthPoints, int armorClass, bool heavyArmor) : base(level, name, stats, healthPoints, armorClass, heavyArmor)
        {
        }
        public static Warrior CreatePlayer(Statistics stats, string name)
        {
            Random rnd = new Random();
            int hp = rnd.Next(6, 12) + stats.ConModifier;
            return new Warrior(1, name, stats, hp, 10, true);
        }
        public override object Clone() 
        { 
            Warrior clone = (Warrior)base.Clone();
            return clone;
        }
        /* Jak zrobic by obiekty internal byly dostepne w innym projekcie, atrybut internals visible to
         Assert is true/false Assert equals, Assert throws, Assert collection equals
        */
    }
}
