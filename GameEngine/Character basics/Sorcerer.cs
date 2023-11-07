using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    internal sealed class Sorcerer : Humanoid
    {
        internal Sorcerer(int level, string name, Statistics stats, int healthPoints, int armorClass, bool heavyArmor) : base(level, name, stats, healthPoints, armorClass, heavyArmor)
        {
        }
        public static Sorcerer CreatePlayer(Statistics stats, string name)
        {
            Random rnd = new Random();
            int hp = rnd.Next(2, 6) + stats.ConModifier;
            return new Sorcerer(1, name, stats, hp, 10, false);
        }
        /* public static  INpc CreateNpc()
         {

         }*/
    }
}
   