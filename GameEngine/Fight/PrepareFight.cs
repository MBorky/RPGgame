using GameEngine;
using System;   
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using GameEngine.Enemies;

namespace GameEngine.Fight
{
    public class PrepareFight
    {
        private List<CharacterInFight> Characters = new();
        public PrepareFight(List<Humanoid> players, int worldLevel)
        {
            AddPlayers(players);
            AddEnemies(players, worldLevel);
            Characters.Sort((p1, p2) => p2.Initiative.CompareTo(p1.Initiative));
            //ActFight = new(Characters);
        }
        // Should it be done by static method like here, or callbacks?
        // I think static methods are ok, because method fight will not be used 
        // with others methods

        public BattleResult StartFight()
        {
            int charactersQueue = 0;
            FightControl fightControl = new(Characters);
            while (fightControl.CheckingAreEnemiesAlive(Characters) && fightControl.CheckingArePlayersCharactersAlive(Characters))
            {
                if (Characters[charactersQueue].Character is EnemyHumanoid)
                {
                    charactersQueue++;
                }
                else
                {
                    var (action, playerAction) = fightControl.SelectAction(charactersQueue);
                    action?.Invoke();
                    charactersQueue++;
                }
                if (charactersQueue == Characters.Count)
                {
                    charactersQueue = 0;
                }
            }
            BattleResult result = new();
            result.BattleSuccess = fightControl.CheckingArePlayersCharactersAlive(Characters);
            return result;
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
                GameEngine.Enemies.EnemyHumanoid enemy = GameEngine.Enemies.EnemyWarrior.CreateEnemy(worldLevel, GenerateName());
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
    }
}


