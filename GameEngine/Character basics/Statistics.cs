using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    internal class Statistics
    {
        public int Strength { get; protected set; }
        public int StrModifier => CalculateModifiers(Strength);
        public int Dexterity { get; protected set; }
        public int DexModifier => CalculateModifiers(Dexterity);
        public int Constitution { get; protected set; }
        public int ConModifier => CalculateModifiers(Constitution);
        public int Intelligence { get; protected set; }
        public int IntModifier => CalculateModifiers(Intelligence);
        public int Wisdom { get; protected set; }
        public int WisModifier => CalculateModifiers(Wisdom);
        public int Charisma { get; protected set; }
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
        public int CalculateModifiers(int stat) 
        {
            return (stat - 10) / 2;
        }
    }
}
