using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Calculator";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            bool contin = true;
            Console.WriteLine("Welcome User. What would you like to do? 1. Classic calculations 2. More Advanced calculations");
            do
            {
                Choose.Mode();
                Console.Write("Do you want to end the programm? (Y = Yes, N = No): ");
                string choice = Console.ReadLine();
                if (choice.ToUpper() == "YES")
                {
                    contin = false;
                }
            } while (contin);
        }
        // Waits for User input and then chooses the mode based on that 
    }
}
