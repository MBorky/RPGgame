using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public static class ConsoleTool
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("1. Create character\n" +
                              "2. Show team\n" +
                              "3. Delete Character\n" +
                              "4. Start Run\n" +
                              "5. Quit");
        }
        public static string ReadFromConsole(string message)
        {
            // I dont know if this is a good idea, but it removes warnings
            string? text;
            Console.WriteLine($"{message}");
            do 
            { 
                text = Console.ReadLine(); 
                if(text == null || text == "")
                {
                    Console.WriteLine("Field cannot be empty! Try again!");
                }
            }while (text  == null || text == "");
            return text;
        }
        public static void DisplayMessage(string message) 
        {
            Console.WriteLine($"{ message}");
        }
        public static int SelectNumber(string message, int range) 
        {
            int select;
            bool properChoice;
            do
            {
                properChoice = Int32.TryParse(ReadFromConsole(message), out select);
            } while (!properChoice || select >= range || select <= 0);
            return select - 1;
        }
    }
}
