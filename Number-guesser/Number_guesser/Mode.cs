using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_guesser
{
    internal class Mode
    {
        public static string Selection(bool firstGuess)
        {
            string difficulty;
            if (firstGuess)
            {
                Console.WriteLine("Welcome to the number guesser!");
                Console.WriteLine("There are three modes.");
            }

            Console.WriteLine("\nEasy: 5 attempts, numbers between 0 and 20\nNormal: 10 attempts, numbers between 0 and 50\nHard: 25 attempts, numbers between 0 and 100\n");

            Console.Write("Which mode do you want? (Enter the word in lowercase letters): ");
            difficulty = Console.ReadLine();

            Settings.ConsoleS(difficulty);
            return difficulty;
        }
    }
}
