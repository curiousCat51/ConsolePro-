using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Classic
    {
        public static void Calculations()
        {
            Console.Write("Welcome to Classic Calculations! Please choose an Operation (+, -, *, /): ");
            switch (Console.ReadLine())
            {
                case "+": Addition.Process(0); break;
                case "-": Subtraction.Process(0); break;
                case "*": Multiplication.Process(0); break;
                case "/": Division.Process(0); break;
                default: Console.WriteLine("Please enter a valid operation"); break;
            }
        }
    }
}
