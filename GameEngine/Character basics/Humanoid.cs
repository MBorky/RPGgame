using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    internal abstract class Humanoid : IPlayer, INpc
    {

        public string Name { get; set; }
        public int Level { get; set; }
        public int HealthPoints { get; set; }
        public Statistics Stats { get; set; }
        public int ArmorClass { get; set; }
        public bool HeavyArmor { get; set; }


        internal Humanoid(int level, string name, Statistics stats, int healthPoints, int armorClass, bool heavyArmor)
        {
            this.Level = level; 
            this.Name = name;
            this.Stats = stats;
            this.HealthPoints = healthPoints;
            this.ArmorClass = armorClass;
            this.HeavyArmor = heavyArmor;
            

        }
    }
    
}
