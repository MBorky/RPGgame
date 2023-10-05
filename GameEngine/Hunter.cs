namespace GameEngine
{
    public class Hunter
    {
        internal sealed class Hunter : Profession
        {
            private Hunter(string name, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int armorClass, int healthPoints) : base(name, strength, dexterity, constitution, intelligence, wisdom, charisma)
            {
                ArmorClass = armorClass;
                HealthPoints = healthPoints;
            }
            public override void LevelUp()
            {
                throw new NotImplementedException();
            }
            public static Create(string name, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int armorClass, int healthPoints)
            {
                return new Hunter(name, strength, dexterity, constitution, intelligence, wisdom, charisma, armorClass, healthPoints);
                // walidace przed utworzeniem, przez exception
            }
        }
    }
}
}