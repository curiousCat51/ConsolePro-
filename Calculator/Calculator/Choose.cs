using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Choose
    {
        public static void Mode()
        {
            bool run = false;
            do
            {
                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        // Classic calculations
                        case 1: Classic.Calculations(); run = true; break;
                        // More advanced calculations
                        case 2: Advanced.Calculations(); run = true; break;
                        //Default case if user enters a number that is not 1 or 2
                        default: Console.WriteLine("Please enter a valid number"); break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number");
                }
            } while (!run);
        }
    }
}
