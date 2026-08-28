using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Rock_Paper_Scissors
{
    internal class Program
    {
        public static int wins = 0;
        public static int losts = 0;
        public static int draws = 0;
        public static string[] moves =
        {
            "rock",
            "paper",
            "scissors"
        };
        static void Main(string[] args)
        {
            Console.Title = "Rock-Paper-Scissors";
            /* Program:
             * Randomly chose one action
             * Let user input action
             * Compare actions
             * - Rock beats scissors
             * - Paper beats rock
             * - Scissors beats paper
             * Output choices and result with explanation
             */

            // Main loop
            do
            {
                Console.WriteLine("Starting a new game...");
                Thread.Sleep(1000);

                Console.Clear();

                Play.Session();

                Console.Clear();

                Console.WriteLine("Are you sure that you want to stop playing? (Press Enter to continue| Press Escape to end)");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            Thread.Sleep(500);
            Console.WriteLine("Shutting down...");
            Thread.Sleep(1000);
        }
    }
}
