using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Statistics
    {
        public int Strength { get; set; }
        public int StrModifier => CalculateModifiers(Strength);
        public int Dexterity { get; set; }
        public int DexModifier => CalculateModifiers(Dexterity);
        public int Constitution { get; set; }
        public int ConModifier => CalculateModifiers(Constitution);
        public int Intelligence { get; set; }
        public int IntModifier => CalculateModifiers(Intelligence);
        public int Wisdom { get; set; }
        public int WisModifier => CalculateModifiers(Wisdom);
        public int Charisma { get; set; }
        public int ChaModifier => CalculateModifiers(Charisma);

        public Statistics()
        {
            Random rnd = new Random();
            Strength = rnd.Next(10, 20);
            Dexterity = rnd.Next(10, 20);
            Constitution = rnd.Next(10, 20);
            Intelligence = rnd.Next(10, 20);
            Wisdom = rnd.Next(10, 20);
            Charisma = rnd.Next(10, 20);
            
        }
        public Statistics (int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;

        }
        public int CalculateModifiers(int stat) 
        {
            return (stat - 10) / 2;
        }
    }
}
