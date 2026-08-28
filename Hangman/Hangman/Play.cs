using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Play
    {
        public static void Session()
        {
            Program.solution = Program.Words[Rnd.Number()];
            char[] so = Program.solution.ToCharArray();
            int mistakes = 0;
            do
            {
                Console.Clear();

                Show.Progress();
                Show.Hangman(mistakes);
                Console.WriteLine(Program.solution);

                Console.WriteLine();

                for (int i = 0; i < so.Length; i++)
                {
                    if (!Program.Wrong.Contains($"{so[i]}") && Program.Right.Contains($"{so[i]}"))
                    {
                        Console.Write($"{so[i]} ");
                        Program.hits++;
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }

                Console.WriteLine();

                Console.WriteLine("Choose input mode: 1 single letter, 2 complete word");
                string input;
                do
                {
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out int _));
                if (Convert.ToInt32(input) == 1)
                {
                    mistakes = Single.Input(mistakes);
                }
                else
                {
                    mistakes = Multi.Input(mistakes);
                }

                if (Program.hits == so.Length)
                {
                    Program.victory = true;
                }
            } while (!Program.victory && mistakes < 9);

            if (Program.victory && mistakes < 9)
            {
                Console.WriteLine("Congrats, you won!");
            }
            else
            {
                Console.WriteLine($"Too bad, the right word was {Program.solution}");
            }
        }
    }
}
