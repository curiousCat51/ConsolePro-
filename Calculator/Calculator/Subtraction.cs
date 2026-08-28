using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Subtraction
    {
        public static void Process(int v)
        {
            if (v == 1)
            {
                Console.Write("Number 1: ");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Number 2: ");
                int num2 = Convert.ToInt32(Console.ReadLine());
                int result = num1 - num2;
                Console.WriteLine($"{num1} - {num2} = {result}");
            }
            else
            {
                Console.Write("Number 1: ");
                string num1 = Console.ReadLine();
                Console.Write("Number 2: ");
                string num2 = Console.ReadLine();
                // Algorithm to subtract two binary number strings without converting them
            }
        }
    }
}
