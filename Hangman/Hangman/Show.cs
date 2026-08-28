using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Show
    {
        public static void Progress()
        {
            // Outputs the right and wrong letters
            Console.WriteLine("Correct letters: ");
            foreach (string letter in Program.Right)
            {
                Console.Write($"{letter} ");
            }
            Console.WriteLine();
            Console.WriteLine("Incorrect letters: ");
            foreach (string letter in Program.Wrong)
            {
                Console.Write($"{letter} ");
            }
        }
        public static void Hangman(int mistakes)
        {
            string[] stage = {
            @"
                    
	              
	              
	              
	                 
            ",
            @"
                    
	              
	              
	              
	              ===
            ",
            @"
                   
	              |
	              |
	              |
	              ===
            ",
            @"
                  +---+
	              |
	              |
	              |
	              ===
            ",
            @"
                  +---+
                  O   |
	              |
	              |
	              ===
            ",
            @"
                  +---+
                  O   |
                  |   |
	              |
	              ===
            ",
            @"
                  +---+
                  O   |
                 /|   |
	              |
	              ===
            ",
            @"
                  +---+
                  O   |
                 /|\  |
	              |
	              ===
            ",
            @"
                  +---+
                  O   |
                 /|\  |
                 /    |
	              ===
            ",
            @"
                  +---+
                  O   |
                 /|\  |
                 / \  |
	              ===
            "
            };

            if (mistakes >= 0 && mistakes < stage.Length)
            {
                Console.WriteLine(stage[mistakes]);
            }
        }
    }
}
