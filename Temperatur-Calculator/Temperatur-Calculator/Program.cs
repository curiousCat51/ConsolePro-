using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperatur_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Temperatur Calculator";
            Console.WriteLine("Welcome to the Temperatur Calculator.");
            Console.Write("Which operation would you like to do? (1 Farenheit in Celsius, 2 Celsius in Farenheit): ");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.Write("Which temperatur (Farenheit) do you have?: ");
                        double F = Convert.ToDouble(Console.ReadLine());
                        double w = Converter.FtoC(F, out double c);
                        Console.WriteLine($"{F}°F is equal to about {c}°C");
                        break;
                    } // F -> C
                case 2:
                    {
                        Console.Write("Which temperatur (Celsius) do you have?: ");
                        double C = Convert.ToDouble(Console.ReadLine());
                        double w = Converter.CtoF(C, out double f);
                        Console.WriteLine($"{C}°C is equal to about {f}°F");
                        break;
                    } // C -> F
                default:
                    {
                        Console.WriteLine("Invalid input");
                        break;
                    }
            }
            Console.WriteLine("Ending programm...");
        }
    }
}