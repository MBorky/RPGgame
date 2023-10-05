using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    internal class Profession
    {
        public string Name { get; protected set; }
        public int Strength { get; protected set; }
        public int Dexterity { get; protected set; }
        public int Constitution { get; protected set; }
        public int Intelligence { get; protected set; }
        public int Wisdom { get; protected set; }
        public int Charisma { get; protected set; }
        public int ArmorClass { get; protected set; }
        public int HealthPoints { get; protected set; }
        public Profession(string name, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
        }
        public abstract void LevelUp();
    }
}
