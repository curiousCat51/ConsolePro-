using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_guesser.Dificulty
{
    internal class Dificulty
    {
        public class Mode
        {
            // Attempts, Number range for generation, dev test number, difficulty, guess state
            private int attempts = 0;
            private int tries = 0;
            private int range = 0;
            private int dev = 2008;
            private string difficulty = "";
            private bool guessed = false;

            // constructor
            public Mode(int attempts, int range, string difficulty)
            {
                this.attempts = attempts;
                this.range = range;
                this.difficulty = difficulty;
            }

            // Getter & Setter
            public int getAttempts() { return attempts; }
            public void setAttempts(int attempts) { this.attempts = attempts; }

            public int getTries() { return tries; }
            public void setTries(int tries) { this.tries = tries; }

            public int getRange() { return range; }
            public void setRange(int range) { this.range = range; }

            public int getDev() { return dev; }

            public string getDifficulty() { return difficulty; }
            public void setDifficulty(string difficulty) { this.difficulty = difficulty; }

            public bool getGuessed() { return guessed; }
            public void setGuessed(bool guessed) { this.guessed = guessed; }

            // Methods
            public void run()
            {
                Console.WriteLine($"In {getDifficulty()} mode: You have {getAttempts()} tries to guess a number in the range from 0 to {getRange()}");
                // Generate random number
                int random = generate(getRange());
                while (getTries() < getAttempts() && !getGuessed())
                {
                    Console.Write("What is your guess?: ");

                    if (!int.TryParse(Console.ReadLine(), out int guess))
                    {
                        Console.WriteLine("Please enter a valid integer.");
                        continue;
                    }

                    // Number guessing algorithm
                    if (guess == getDev())
                    {
                        // Dev function
                        Console.WriteLine("Dev test successful!\n");
                        Console.WriteLine($"The number you're looking for is {random}");

                    }
                    else if (guess != random && getTries() < getAttempts())
                    {
                        setTries(getTries() + 1);
                        if (guess > random)
                        {
                            Console.WriteLine("Your number is too big, try a smaller number.");
                        }
                        else
                        {
                            Console.WriteLine("Your number is too small, try a bigger number.");
                        }
                        Console.WriteLine($"You have {getAttempts() - getTries()} tries left!\n");
                    }
                    else
                    {
                        setGuessed(!getGuessed());
                        break;
                    }
                }

                if (getGuessed())
                {
                    Console.WriteLine("Well done, you guessed the number correctly!\n");
                }
                else
                {
                    Console.WriteLine($"The number you were looking for is {random}. Too bad, better luck next time!\n");
                }
            }
            public static int generate(int range)
            {
                Random rnd = new Random();
                int random = rnd.Next(0, range + 1);
                return random;
            }
        }

    }
}
