using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Fight
{
    internal class PlayerActions
    {
        List<CharacterInFight> Characters;
        private Func<string, int, int> ReadNumberFromConsole = ConsoleTool.SelectNumber;
        public PlayerActions(List<CharacterInFight> characters) 
        {
            Characters = characters;
        }   
        internal void Attack()
        {
            SelectEnemy().HealthPoints = ;
            Console.WriteLine($"Attack!");
        }
        internal void UseItem()
        {
            Console.WriteLine($"UseItem");
        }
        internal void UseSkill()
        {
            Console.WriteLine($"UseSkill");
        }
        
        private GameEngine.Enemies.EnemyHumanoid SelectEnemy()
        {
            int enemiesNumber = 1;
            StringBuilder enemiesInfo = new StringBuilder();
            Dictionary<int, GameEngine.Enemies.EnemyHumanoid> enemies = new();
            // Making dictionary of enemies with HP
            foreach (var character in Characters)
            {
                if (character.Character is GameEngine.Enemies.EnemyHumanoid enemy && enemy.HealthPoints > 0)
                {
                    enemies.Add(enemiesNumber, enemy);

                    enemiesInfo.AppendLine($"{enemiesNumber}. {enemy.Name}");
                    enemiesNumber++;
                }
            }
            // Choosing enemy
            int select = ReadNumberFromConsole($"Select Enemy\n{enemiesInfo.ToString()}", enemiesNumber);
            return enemies[select];
        }
    }
}
// Making all actions as a new objects with implemented interface IAction
// IAction with method Execute or empty
// zrobić save game
// Zastanowić się jak to będzie działać, jak będą statić to jebać i zrobić w jednej klasie, jak będą 
// bardziej złożone z wyminą informacji to każda akcja jako klasa