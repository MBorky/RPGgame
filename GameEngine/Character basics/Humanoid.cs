using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public abstract class Humanoid : ICloneable, ICharacter
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
            // zrobic walidacje
        }
        public virtual object Clone()
        {
            Humanoid clone = (Humanoid)MemberwiseClone();
            clone.Stats = new Statistics(Stats.Intelligence, Stats.Dexterity, Stats.Constitution, Stats.Intelligence, Stats.Wisdom, Stats.Charisma);
            return clone;
        }
        /*void DisplayAction(List<Action> actions)
        {
            foreach (Action action in actions)
            {
                //action.Display;
            }
        }*/
    }
}
