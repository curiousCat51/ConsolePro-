using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Multi
    {
        public static int Input(int mistakes)
        {
            Console.Write("You are in multi input mode, please enter a word (All letters are written in lower case): ");
            string word = Console.ReadLine();

            if (Program.solution == word)
            {
                Console.WriteLine($"{word} is the correct word.");
                Program.victory = true;
            }
            else
            {
                Console.WriteLine($"{word} is not the correct word.");
                mistakes += 2;
            }
            return mistakes;
        }
    }
}
