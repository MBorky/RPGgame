using System;
namespace GameEngine
{
    internal sealed class EnemyWarrior : EnemyHumanoid
    {
        internal EnemyWarrior(int level, string name, int healthPoints, int armorClass) : base(level, name, healthPoints, armorClass)
        {
            if (level > 1)
            {
                for (int i = 1; i < level; i++)
                {
                    ArmorClass += 1;
                    Random rnd = new();
                    int statChoice = rnd.Next(1, 3);
                    switch (statChoice)
                    {
                        case 1:
                            Stats.Strength += 1;
                            break;
                        case 2:
                            Stats.Dexterity += 1;
                            break;
                        case 3:
                            Stats.Constitution += 1;
                            break;
                    }
                    HealthPoints += rnd.Next(1, 12) + Stats.ConModifier;
                }
            }
        }
        public static EnemyWarrior CreateEnemy(int level, string name)
        {
            Random rnd = new Random();
            int hp = rnd.Next(1, 12);
            return new EnemyWarrior(level, name, hp, 10);
        }
    }
}

