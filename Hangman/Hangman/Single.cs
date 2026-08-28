using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Single
    {
        public static int Input(int mistakes)
        {
            bool correct = false;
            char[] s = Program.solution.ToCharArray();
            Console.Write("You are in single input mode, please enter a letter (All letters are written in lower case): ");
            string input = "";
            do
            {
                input = Console.ReadLine();
            } while (!char.TryParse(input, out char _));

            char letter = Convert.ToChar(input);

            if (!Program.Right.Contains($"{letter}") && !Program.Wrong.Contains($"{letter}"))
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == letter)
                    {
                        correct = true;
                    }

                }

                if (correct)
                {
                    Program.Right.Add($"{letter}");
                }
                else
                {
                    Program.Wrong.Add($"{letter}");
                    mistakes++;
                }
            }

            return mistakes;
        }
    }
}
