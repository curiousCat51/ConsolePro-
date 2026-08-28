using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Calculator
{
    public class AgeX
    {
        // Past age
        public static void Age(int curYear)
        {
            Console.Write("How old are you currently?: ");
            int agePre = Convert.ToInt32(Console.ReadLine());

            Console.Write($"What year do you want to go back to? (Format of 4 Numbers ex. {curYear}): ");
            int paYear = Convert.ToInt32(Console.ReadLine());

            int ageDif = 0;

            if (paYear < curYear)
            {
                ageDif = curYear - paYear;
            }
            else
            {
                Console.WriteLine($"The choosen year {paYear} is bigger than the current year \n and thereby for this calculation invalid. Perhaps try option 3");
            }

            Console.WriteLine($"In {paYear} you were about {agePre - ageDif} years old");
        }
    }
}
