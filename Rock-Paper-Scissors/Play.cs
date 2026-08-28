using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    internal class Play
    {
        public static void Session()
        {
            // Connection point of all game methods
            do
            {
                int opBot = Gen.RandNumb();
                int opPlayer = ActionChoosingPlayer();
                Duel(opBot, opPlayer);
                Console.WriteLine($"You won {Program.wins} games, lost {Program.losts} games and achieved {Program.draws} Program.draws.");
                Console.WriteLine("Press enter to play again\nPress escape to end");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        public static void Duel(int Bot, int Player)
        {
            // Console.WriteLine()
            Player--;
            if (Bot == 1)
            {
                if (Player == 2)
                {
                    Console.WriteLine($"{Program.moves[Bot]} - {Program.moves[Player]}");
                    Console.WriteLine($"Player Program.wins because {Program.moves[Player]} beats {Program.moves[Bot]}");
                    Program.wins++;
                }
                else if (Player == 3)
                {
                    Console.WriteLine($"{Program.moves[Bot]} - {Program.moves[Player]}");
                    Console.WriteLine($"Bot Program.wins because {Program.moves[Bot]} beats {Program.moves[Player]}");
                    Program.losts++;
                }
                else
                {
                    Console.WriteLine($"{Program.moves[Bot]} - {Program.moves[Player]}");
                    Console.WriteLine($"No one Program.wins because {Program.moves[Player]} and {Program.moves[Bot]} are the same");
                    Program.draws++;
                }
            }
            else if (Bot == 2)
            {
                if (Player == 1)
                {
                    Console.WriteLine($"{Program.moves[Bot]} - {Program.moves[Player]}");
                    Console.WriteLine($"Bot Program.wins because {Program.moves[Bot]} beats {Program.moves[Player]}");
                    Program.losts++;
                }
                else if (Player == 3)
                {
                    Console.WriteLine($"{Program.moves[Bot]} - {Program.moves[Player]}");
                    Console.WriteLine($"Player Program.wins because {Program.moves[Player]} beats {Program.moves[Bot]}");
                    Program.wins++;
                }
                else
                {
                    Console.WriteLine($"{Program.moves[Bot]} - {Program.moves[Player]}");
                    Console.WriteLine($"No one Program.wins because {Program.moves[Player]} and {Program.moves[Bot]} are the same");
                    Program.draws++;
                }
            }
            else
            {
                if (Player == 1)
                {
                    Console.WriteLine($"{Program.moves[Bot]} - {Program.moves[Player]}");
                    Console.WriteLine($"Player Program.wins because {Program.moves[Player]} beats {Program.moves[Bot]}");
                    Program.wins++;
                }
                else if (Player == 2)
                {
                    Console.WriteLine($"{Program.moves[Bot]} - {Program.moves[Player]}");
                    Console.WriteLine($"Bot Program.wins because {Program.moves[Bot]} beats {Program.moves[Player]}");
                    Program.losts++;
                }
                else
                {
                    Console.WriteLine($"{Program.moves[Bot]} - {Program.moves[Player]}");
                    Console.WriteLine($"No one Program.wins because {Program.moves[Player]} and {Program.moves[Bot]} are the same");
                    Program.draws++;
                }
            }
        }
        public static int ActionChoosingPlayer()
        {
            int move = 0;
            string input;

            Console.Clear();
            Console.WriteLine("- rock\n- paper\n- scissors\n.h for help");
            Console.Write("\nChoose your action:");

            do
            {
                do
                {
                    input = Console.ReadLine().ToLower();
                } while (string.IsNullOrEmpty(input));

                switch (input)
                {
                    case "rock":
                        {
                            move = 1; break;
                        }
                    case "paper":
                        {
                            move = 2; break;
                        }
                    case "scissors":
                        {
                            move = 3; break;
                        }
                    case ".h":
                        {
                            Help.h(); break;
                        }
                    default:
                        {
                            Console.WriteLine("Your input was invalid. Please try one of the options above.");
                            break;
                        }
                }
            } while (move == 0);
            return move;
        }
    }
}
