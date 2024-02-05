
namespace GameEngine.Fight
{
    internal class CharacterInFight
    {
        internal int Initiative {get; set;}
        internal ICharacter? Character {get;}
        internal CharacterInFight(ICharacter character)
        {   
            Random rnd = new Random();
            if(character is Humanoid player)
            {
                Initiative = player.Stats.DexModifier + rnd.Next(1, 20);
                Character = (ICharacter)player.Clone();
                Console.WriteLine($"{player.Name} Initiative: {Initiative}");

            }
            else if(character is GameEngine.Enemies.EnemyHumanoid enemy)
            {
                Initiative = enemy.Stats.DexModifier + rnd.Next(1, 20);
                Character = character;
                Console.WriteLine($"{enemy.Name} Initiative: {Initiative}");
            }
            
        }
    }
}