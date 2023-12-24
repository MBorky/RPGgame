using GameEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fight
{
    public class StartFight
    {
        List<CharacterInFight> Characters = new();
        public StartFight(List<Humanoid> players, int worldLevel)
        {
            AddPlayers(players);
            AddEnemies(players, worldLevel);
        }
        internal void AddPlayers(List<Humanoid> players)
        {
            foreach (var player in players)
            {
                Characters.Add(player.Clone());
            }
        }
        internal void AddEnemies(List<Humanoid> players, int worldLevel)
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
        // Read about linq, most popular methods in linq, learn about lambda expression
        /*private void DetermineInitiative(List<object> characters)
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

        }*/
       private bool CheckingAreEnemiesAlive()
        {
            foreach (var character in Characters)
            {
                if (character is GameEngine.EnemyHumanoid enemy)
                {
                    if (enemy.HealthPoints > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
       private bool CheckingArePlayersCharactersAlive()
        {
            foreach (var character in Characters)
            {
                if (character is GameEngine.Humanoid player)
                {
                    if (player.HealthPoints > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
       /*
        * Fight has got event which change world level, end game or smthg
        * jeszcze lepiej wzorzec obserwator do ogarnięcia
        */
       public void Fight()
       {   
            while (CheckingAreEnemiesAlive() == true && CheckingArePlayersCharactersAlive() == true) 
            {

            }
            if (CheckingArePlayersCharactersAlive() == false)
            {
                return ;
            }
            return true;
       }
       private void SelectAction()
       {

       }
       private EnemyHumanoid SelectEnemy()
       {
            int i = 1;
            StringBuilder EnemiesInfo = new StringBuilder();
            Dictionary<int, EnemyHumanoid> enemies = new ();
            // Making list of enemies with HP
            foreach(var character in Characters)
            {
                if (character is EnemyHumanoid enemy && enemy.HealthPoints > 0)
                {
                    enemies.Add(i, enemy);

                    EnemiesInfo.AppendLine($"{i}. {enemy.Name}");
                    i++;
                }   
            }
            // Choosing enemy
       }
       private void Attack()
       {

       }
    }

    public class BattleResult
    {
    }
}
/*
 * Iziemy po liście, która jest ustawiona według inicjatywy, inicjatywy nie da się zmienić podczas walki.
 * Osoba, która umiera jest usuwana z listy, czyli nie będzie wogóle możliwości padniętej osoby wskrzeszania?
 * Ew kolejna lista może być shallow copy, na wszelki wypadek
 */
