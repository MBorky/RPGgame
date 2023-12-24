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
            Characters.Sort((p1,p2) => p2.Initiative.CompareTo(p1.Initiative));
        }
        internal void AddPlayers(List<Humanoid> players)
        {
            foreach (var player in players)
            {
                Characters.Add(new CharacterInFight(player));
            }
        }
        internal void AddEnemies(List<Humanoid> players, int worldLevel)
        {
            foreach (var player in players)
            {
                EnemyHumanoid enemy = EnemyWarrior.CreateEnemy(worldLevel, GenerateName());
                Characters.Add(new CharacterInFight(enemy));
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
       /*private bool CheckingAreEnemiesAlive()
        {
            foreach (var character in Characters)
            {
                if (character.Character is EnemyHumanoid enemy)
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
       
        //Fight has got event which change world level, end game or smthg
        //jeszcze lepiej wzorzec obserwator do ogarnięcia
    
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
                if (character.Character is EnemyHumanoid enemy && enemy.HealthPoints > 0)
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

       }*/
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
