using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Calculator
{
    internal class Program
    {
        public static int curYear = 2026;
        static void Main(string[] args)
        {
            Console.Title = "Age Calculator";
            bool conti = true;
            Console.WriteLine("Welcome to the Age-Calculator!");
            do
            {
                Console.WriteLine("What Operation do you want?");
                Console.WriteLine("- Calculate how old you were x years ago (1)");
                Console.WriteLine("- Calculate your current age (2)");
                Console.WriteLine("- Calculate how old you will be in the year x (3)");
                int op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1: AgeX.Age(curYear); break;
                    case 2: Age.AgeN(curYear); break;
                    case 3: XAge.Age(curYear); break;
                    default: Console.WriteLine("Input was Invalid"); break;
                }

                Console.Write("Do you want to continue? (Y = Yes, N = No): ");
                string goOn = Console.ReadLine();

                if (goOn.ToUpper() == "N")
                {
                    conti = false;
                }
                else
                {
                    Console.Clear();
                }

            } while (conti);
            Console.WriteLine("Ending programm...");
        }
    }
}
