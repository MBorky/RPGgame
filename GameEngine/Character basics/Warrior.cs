﻿using System;
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
        public static IPlayer CreatePlayer(Statistics stats, string name)
        {
            Random rnd = new Random();
            int hp = rnd.Next(6, 12) + stats.ConModifier;
            return new Warrior(1, name, stats, hp, 10, true);
        }
       /* public static  INpc CreateNpc()
        {
            
        }*/
    }
}
