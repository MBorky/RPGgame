using System;
namespace GameEngine
{
    internal abstract class EnemyHumanoid : ICharacter
    {

        public string Name { get; set; }
        public int Level { get; set; }
        public int HealthPoints { get; set; }
        public Statistics Stats { get; set; }
        public int ArmorClass { get; set; }
       


        internal EnemyHumanoid(int level, string name, int healthPoints, int armorClass)
        {
            this.Level = level;
            this.Name = name;
            this.Stats = new();
            this.HealthPoints = healthPoints + Stats.ConModifier;
            this.ArmorClass = armorClass;
        }
    }
}


