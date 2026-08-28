using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_guesser
{
    internal class Settings
    {
        public static void ConsoleS(string difficulty)
        {
            Console.Title = difficulty;

            if (difficulty == "easy")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (difficulty == "normal")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
    }
}
