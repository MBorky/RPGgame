using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GameEngine.Fight
{
    internal class FightFlowControl
    {
        List<CharacterInFight> Characters;
        private Func<string, int, int> ReadNumberFromConsole = ConsoleTool.SelectNumber;
        public FightFlowControl(List<CharacterInFight> characters) 
        {
            Characters = characters;
        }
        internal CharacterInFight Tour(int tourInFight)
        {
            if (Characters[tourInFight].Character is GameEngine.Enemies.EnemyHumanoid)
            { }
            else
            {
                SelectAction(tourInFight);
            }
        }
       internal (Action, PlayerActions) SelectAction()
        {
            int methodNumber = 0;
            PlayerActions actFight = new(Characters);
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



    }
}
