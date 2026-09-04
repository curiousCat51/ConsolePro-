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

            if (word != null && word.Length == Program.solution.Length)
            {
                bool exact = word == Program.solution;

                for (int i = 0; i < Program.solution.Length; i++)
                {
                    string solChar = Program.solution.Substring(i, 1);
                    string wordChar = word.Substring(i, 1);

                    if (wordChar == solChar)
                    {
                        if (!Program.Right.Contains(wordChar))
                        {
                            Program.Right.Add(wordChar);
                        }
                    }
                    else
                    {
                        // If the guessed character exists anywhere in the solution, treat it as a correct letter (wrong position).
                        if (Program.solution.Contains(wordChar))
                        {
                            if (!Program.Right.Contains(wordChar))
                            {
                                Program.Right.Add(wordChar);
                            }
                        }
                        else
                        {
                            if (!Program.Wrong.Contains(wordChar))
                            {
                                Program.Wrong.Add(wordChar);
                            }
                        }
                    }
                }

                if (exact)
                {
                    Console.WriteLine($"{word} is the correct word.");
                    Program.victory = true;
                }
                else
                {
                    Console.WriteLine($"{word} is not the correct word.");
                    mistakes += 2;
                }
            }
            else
            {
                Console.WriteLine($"{word} is too short.");
                mistakes += 2;
            }

            return mistakes;
        }
    }
}
