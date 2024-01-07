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
    public class StartFight
    {
        private List<CharacterInFight> Characters = new();
        PlayerActions playerActions;
        //ActionsInFight ActFight;
        private Action<string> Message = ConsoleTool.DisplayMessage;
        private Func<string, string> ReadFromConsole = ConsoleTool.ReadFromConsole;
        private Func<string, int, int> ReadNumberFromConsole = ConsoleTool.SelectNumber;
        public StartFight(List<Humanoid> players, int worldLevel)
        {
            AddPlayers(players);
            AddEnemies(players, worldLevel);
            Characters.Sort((p1, p2) => p2.Initiative.CompareTo(p1.Initiative));
            playerActions = new(Characters);
            //ActFight = new(Characters);
        }
        public bool Fight()
        {
            int tour = 1;
            while (CheckingAreEnemiesAlive() == true && CheckingArePlayersCharactersAlive() == true)
            {
                
                var (action, actionsInFight) = fightFlowControl.SelectAction();
                action.Invoke();
            }
            if (CheckingArePlayersCharactersAlive() == false)
            {
                return false;
            }
            return true;
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
        private bool CheckingAreEnemiesAlive()
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
       
        // Learning process about reflection and return instance and methods in delegates
        // I think normally i should make ActionInFight static, because this methods are not dependent on the instance state
        
        

        public class BattleResult
        {
        }
    }
}

/*
 * Za pomoca lub delegat lub refleksji zrobic metode ktora wywoluje metody. Tworzy tablice z metodami, ktora sie
 * dynamicznie powieksza. Dzieki czemu jedna metoda select action pozwala wywolac metody z minimalna iloscia kodu.
 * Jesli delegaty to metody musza miec te same parametry i return type
 * Iziemy po liście, która jest ustawiona według inicjatywy, inicjatywy nie da się zmienić podczas walki.
 * Osoba, która umiera jest usuwana z listy, czyli nie będzie wogóle możliwości padniętej osoby wskrzeszania?
 * Ew kolejna lista może być shallow copy, na wszelki wypadek
 */
