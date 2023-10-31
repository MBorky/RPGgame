namespace GameEngine
{
    internal sealed class Hunter : Humanoid
    {
        internal Hunter(int level, string name, Statistics stats, int healthPoints, int armorClass, bool heavyArmor) : base(level, name, stats, healthPoints, armorClass, heavyArmor)
        {
        }
        public static IPlayer CreatePlayer(Statistics stats, string name)
        {
            Random rnd = new Random();
            int hp = rnd.Next(4, 8) + stats.ConModifier;
            return new Hunter(1, name, stats, hp, 10, false);
        }
        /* public static  INpc CreateNpc()
         {

         }*/
    }
}
   