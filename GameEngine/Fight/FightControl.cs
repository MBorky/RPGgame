using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GameEngine.Fight
{
    internal class FightControl
    {
        List<CharacterInFight> Characters;
        private Func<string, int, int> ReadNumberFromConsole = ConsoleTool.SelectNumber;
        private Action<string> DisplayMessage = ConsoleTool.DisplayMessage;
        public FightControl(List<CharacterInFight> characters) 
        {
            Characters = characters;
        }
        internal (Action, PlayerActions) SelectAction(int characterQueue)
        {
            int methodNumber = 0;
            PlayerActions actFight = new(Characters, characterQueue);
            Type classType = typeof(PlayerActions);
            BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance;
            MethodInfo[] methodsInFight = classType.GetMethods(flags);

            // Building string with methods name
            StringBuilder methodsStrings = new StringBuilder();

            foreach (MethodInfo method in methodsInFight)
            {
                // Maybe better use methodsInFight.Length;
                methodNumber++;
                methodsStrings.AppendLine($"{methodNumber}. {method.Name}");
            }

            int selectedNumber = ReadNumberFromConsole($"Select Action\n{methodsStrings.ToString()}", methodNumber);
            Action actionDel = (Action)Delegate.CreateDelegate(typeof(Action), actFight, methodsInFight[selectedNumber]);
            return (actionDel, actFight);
        }
        internal bool CheckingAreEnemiesAlive(List<CharacterInFight> Characters)
        {
            foreach (var character in Characters)
            {
                if (character.Character is GameEngine.Enemies.EnemyHumanoid enemy)
                {
                    if (enemy.HealthPoints > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        internal bool CheckingArePlayersCharactersAlive(List<CharacterInFight> Characters)
        {
            foreach (var character in Characters)
            {
                if (character.Character is Humanoid player)
                {
                    if (player.HealthPoints > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
