using GameEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight
{
    public class StartFight
    {
        List<object> Characters = new();
        Queue<object> InitiativeQueue = new Queue<object>();
        public StartFight(List<GameEngine.Humanoid> players, int worldLevel)
        {
            AddPlayers(players);
            AddEnemies(players, worldLevel);
        }
        private void AddPlayers(List<GameEngine.Humanoid> players)
        {
            foreach (var player in players)
            {
                Characters.Add(player.Clone());
            }
        }
        private void AddEnemies(List<GameEngine.Humanoid> players, int worldLevel)
        {
            foreach (var player in players)
            {
                Characters.Add(EnemyWarrior.CreateEnemy(worldLevel, GenerateName()));
            }
        }
        private string GenerateName()
        {
            Random rnd = new Random();
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            string name = "";

            for (int i = 0, j = rnd.Next(5, 10); i < j; i++) 
            {
                if (i == 0)
                {
                    name += char.ToUpper(alphabet[rnd.Next(0, 25)]);
                }
                else 
                {
                    name += alphabet[rnd.Next(0, 35)];
                }
            }
            return name;
        }
        private void DetermineInitiative(List<object> characters)
        {
            int tempValue;
            Random rnd = new Random();
            foreach (var character in characters) 
            {   
               if (character is GameEngine.Humanoid player)
               {
               
               }
               else if (character is GameEngine.EnemyHumanoid enemy) 
               {
               }
               else
               {
               }
              
            }

        }
    }
}
/*
 * Iziemy po liście, która jest ustawiona według inicjatywy, inicjatywy nie da się zmienić podczas walki.
 * Osoba, która umiera jest usuwana z listy, czyli nie będzie wogóle możliwości padniętej osoby wskrzeszania?
 * Ew kolejna lista może być shallow copy, na wszelki wypadek
 */
