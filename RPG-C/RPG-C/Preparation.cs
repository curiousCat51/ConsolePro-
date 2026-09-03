using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPG_C
{
    internal class Preparation
    {
        public static Player P1 = new Player("", 0, 0, 0, "");
        public Preparation()
        {
        }
        public static void CharacterCreation()
        {
            string classInput;
            bool validClass = false;
            int result;

            Console.Title = "Character Creation";

            Console.Write("Möchten Sie einen eigenen Charakter erstellen (J = Ja/ N = Nein)?: ");
            if (Console.ReadLine().ToUpper() == "J")
            {
                Console.Write("\nGeben Sie den Namen Ihres Charakters ein: ");
                P1.setName(Console.ReadLine());

                Console.WriteLine("\nKlassen:\n1 Krieger*in\n2 Assasine\n3 Heiler*in\n4 Tank");
                do
                {
                    Console.Write("\nGeben Sie die Nummer der gewünschten Klasse ein (!Bei ungültiger Eingabe werden die Standardwerte verwendet!): ");
                    classInput = Console.ReadLine();
                    if (int.TryParse(classInput, out result))
                    {
                        validClass = true;
                    }
                } while (!validClass);

                switch (result)
                {
                    case 1:
                        {
                            P1.setHealthp(1200);
                            P1.setArmorp(150);
                            P1.setDamage(100);
                            break;
                        }
                    case 2:
                        {
                            P1.setHealthp(800);
                            P1.setArmorp(100);
                            P1.setDamage(150);
                            break;
                        }
                    case 3:
                        {
                            P1.setHealthp(900);
                            P1.setArmorp(120);
                            P1.setDamage(80);
                            Program.inventory["Items"].Add("Großer Lebenspunkte Trank", 4);
                            break;
                        }
                    case 4:
                        {
                            P1.setHealthp(1500);
                            P1.setArmorp(200);
                            P1.setDamage(50);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Ungültige Eingabe. Standardwerte werden verwendet.");
                            Thread.Sleep(1000);
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Standartwerte werden verwendet");
                P1.setName("Hanibal");
                P1.setHealthp(1000);
                P1.setArmorp(200);
                P1.setDamage(75);
            }
        }
    }
}
