using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Calculator
{
    internal class XAge
    {
        // Future age
        public static void Age(int curYear)
        {
            Console.Write("What year in the future do you want to go to?: ");
            int yearF = Convert.ToInt32(Console.ReadLine());

            Console.Write("How old are you currently?: ");
            int agePre = Convert.ToInt32(Console.ReadLine());

            int ageDif = 0;
            if (yearF > curYear)
            {
                ageDif = yearF - curYear;
            }
            else
            {
                Console.WriteLine($"The year {yearF} is smaller than the current year\n and thereby invalid for this calculation. Perhaps try option 1");
            }

            Console.WriteLine($"In {yearF} you will be {agePre + ageDif} years old");
        }
    }
}
