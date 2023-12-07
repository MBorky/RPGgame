using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class TeamManager
    {
        
        public List<Humanoid> Players = new List<Humanoid>();
        Action<string> Message = ConsoleTool.DisplayMessage;
        Func<string, string> ReadFromConsole = ConsoleTool.ReadFromConsole;
        public TeamManager() 
        {
            /* wyekstrachowac czesc losujaca, czy tez wywalic na zewnatrz wybor postaci
             Rozbic na oddzielne metody*/
            for (int i = 0; i < 3; i++) 
            {
                Statistics stats = new Statistics();
                PropertyInfo[] propertyInfos = typeof(Statistics).GetProperties();

                Message("Rolled statistics:\n");

                foreach (PropertyInfo property in propertyInfos) 
                { 
                    Message($"{property.Name}: {property.GetValue(stats)}");
                }
                string charName = ReadFromConsole("Type character name:");

                Message("Which class you want to create?\n" +
                        "1. Warrior\n" +
                        "2. Sorcerer\n" +
                        "3. Hunter\n");

                int character = 0;
                bool properChoice = false;
                do
                {
                    properChoice = Int32.TryParse(ReadFromConsole("choose number"), out character);
                    if (character == 1)
                    {
                        Players.Add(Warrior.CreatePlayer(stats, charName));

                    }
                    else if (character == 2)
                    {
                        Players.Add(Sorcerer.CreatePlayer(stats, charName));
                    }
                    else if(character == 3)
                    {
                        Players.Add(Hunter.CreatePlayer(stats, charName));
                    }
                } while (character > 3 || character < 1 || properChoice == false);
            }
        }
        public string ShowTeamInfo()
        {
            string charactersInfo = "";
            StringBuilder charInfo = new StringBuilder();
            foreach(Humanoid character in Players) 
            {
                if (character is Humanoid profession)
                {
                    string prof = "";
                    if (character is Warrior) { prof = "Warrior"; }
                    else if (character is Sorcerer) { prof = "Sorcerer"; }
                    else if (character is Hunter) { prof = "Hunter"; }
                    
                    charInfo.AppendLine($"Name: {profession.Name} " + 
                                        $"Class: {prof} " +
                                        $"Level: {profession.Level}\n" +
                                        $"HP: {profession.HealthPoints} " +
                                        $"Armor class: {profession.ArmorClass} " +
                                        $"Using heavy armor: {profession.HeavyArmor}\n");
                    PropertyInfo[] propertyInfos = typeof(Statistics).GetProperties();
                    int i = 2;
                    foreach (PropertyInfo property in propertyInfos)
                    {
                        if (i % 2 == 0)
                        { charInfo.Append($"{property.Name}: {property.GetValue(profession.Stats)}"); }
                        else 
                        { charInfo.AppendLine($" {property.Name}: {property.GetValue(profession.Stats)}"); }
                        i++;
                    }
                }
             charInfo.Append( "\n\n\n" );
            }
            charactersInfo = charInfo.ToString();
            return charactersInfo;
        }
        
    }
}
