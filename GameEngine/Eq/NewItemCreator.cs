using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace GameEngine.Eq
{
    // Zrobiłem klasę Armor public, jej dziedziczące zostawiłem internal, czy to ok?
    // internals visible to - dzieki temu mozna internals w program.cs uzyc, tak by klasa nie byla publiczna
    // Testy do new item creator
    public enum ArmorTypes
    {
        LightArmor = 0,
        HeavyArmor = 1,
    }
    public class NewItemCreator
    {
        WorldLevel _worldLevel;
        Random rnd = new Random();
        List<Humanoid> Players;
        private Func<string, int, int> ReadNumberFromConsole = ConsoleTool.SelectNumber;
        public NewItemCreator(WorldLevel worldLevel, List<Humanoid> players)
        {
            _worldLevel = worldLevel;
            Players = players;
        }
        // Czy to jest bardzo chujowe?
        //uzyc zamiast inta enum, w pierwszych funkcjach uzyc rzutowania (cast)
        // Testy klas
        public Armor CreateArmor()
        {
            int i = rnd.Next(0, 2);
            return CreateArmor(i);
        }
        public Weapon CreateWeapon()
        {
            int i = rnd.Next(0, 2);
            return CreateWeapon(i);
        }
        public Armor CreateArmor(int i)
        {
            if (i == 0)
            {
                return new LightArmor(_worldLevel.Level);
            }
            else
            {
                return new HeavyArmor(_worldLevel.Level);
            }
        }
        public Weapon CreateWeapon(int i)
        {
            if (i == 0)
            {
                return new Axe(_worldLevel.Level);
            }
            else
            {
                return new Sword(_worldLevel.Level);
            }
        }
        public void AddWeaponToPlayer()
        {
            Armor armor = CreateArmor();
            Weapon weapon = CreateWeapon();
            // dodac walidacje czy armor heavy true
            // Dodac teksty
            Humanoid player = ChoosePlayer();
            player.Equipment.Weapon = weapon;
            if (armor is LightArmor) { }
        }
        public Humanoid ChoosePlayer()
        {
            StringBuilder playersInfo = new StringBuilder();
            int i = 1;
            foreach (var player in Players)
            {
                playersInfo.AppendLine($"{i}. {player.Name}");
                i++;
            }
            // Choosing enemy
            int select = ReadNumberFromConsole($"Select ally\n{playersInfo.ToString()}", i);
            return Players[select - 1];
        }
    }
}
