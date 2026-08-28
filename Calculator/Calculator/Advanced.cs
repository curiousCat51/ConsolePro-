using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Advanced
    {
        public static void Calculations()
        {
            Console.Write("Welcome to Advanced Calculations! Please choose an binary Operation (+, -, *, /): ");
            switch (Console.ReadLine())
            {
                case "+": Addition.Process(1); break;
                case "-": Subtraction.Process(1); break;
                case "*": Multiplication.Process(1); break;
                case "/": Division.Process(1); break;
                default: Console.WriteLine("Please enter a valid operation"); break;
            }
        }
    }
}
