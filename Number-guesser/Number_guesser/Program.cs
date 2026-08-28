using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_guesser
{
    public class Program
    {
        // Probleme auf andere Klassen zuzugreifen
        static void Main(string[] args)
        {
            Console.Title = "Number guesser";
            bool firstGuess = true;

            // Dificulty stages as objects
            Dificulty.Dificulty.Mode easy = new Dificulty.Dificulty.Mode(5, 20, "easy");
            Dificulty.Dificulty.Mode normal = new Dificulty.Dificulty.Mode(10, 50, "normal");
            Dificulty.Dificulty.Mode hard = new Dificulty.Dificulty.Mode(25, 100, "hard");
            bool contin = false;

            // Main Loop
            do
            {
                switch (Mode.Selection(firstGuess))
                {
                    case "easy": Console.Clear(); easy.run(); break;
                    case "normal": Console.Clear(); normal.run(); break;
                    case "hard": Console.Clear(); hard.run(); break;
                    default:
                        {
                            Console.WriteLine("You have to enter a mode if you want to play\n\n"); break;
                        }
                }

                Console.ForegroundColor = ConsoleColor.White;

                if (firstGuess)
                {
                    firstGuess = !firstGuess;
                }

                Console.Write("Do you want to play another game? (Y = Yes, N = No): ");
                if (Console.ReadLine() == "N")
                {
                    contin = false;
                }
                else
                {
                    contin = true;
                    Console.Clear();
                }

            } while (contin);

            Console.WriteLine("Ending programm...");
        }
    }
}