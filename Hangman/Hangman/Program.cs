using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Program
    {
        public static List<string> Wrong = new List<string>();
        public static List<string> Right = new List<string>();
        // List of words
        public static List<string> Words = new List<string> {
            "banana",
            "apple",
            "cowboy",
            "alien",
            "donkey"
        };
        public static bool victory = false;
        public static string solution = "";
        public static int maxLength = 6;
        public static int hits = 0;
        static void Main(string[] args)
        {
            /* Program:
             * - Word from a specified selection (random choose) ✓
             * - Loop starting/ restarting the game
             * - User chooses input mode (single letter/ full word)
             * - Compare input to word from the list
             * - Save corret and incorrect letters if not already saved
             * - Write the progress in the console
             */

            Console.Title = "Hangman";
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Welcome to Hangman.");
            do
            {
                Play.Session();
                Console.Write("Do you want to play again? (y = yes, n = no): ");
            } while (Console.ReadLine() == "y");

            Console.WriteLine("Shutting down...");
            Console.ReadKey();
        }
    }
}