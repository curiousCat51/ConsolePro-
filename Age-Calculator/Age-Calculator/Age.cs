using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Calculator
{
    internal class Age
    {
        // Current Age
        public static void AgeN(int curYear)
        {
            Console.Write($"In which year were you born? (Format of 4 Numbers ex. {curYear}): ");
            int birthY = Convert.ToInt32(Console.ReadLine());

            int age = curYear - birthY;
            Console.WriteLine($"You are {age} years old");
        }
    }
}
