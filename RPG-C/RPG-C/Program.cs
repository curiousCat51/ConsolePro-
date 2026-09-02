using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C
{
    internal class Program
    {
        //Items
        public static Dictionary<string, Items> items = new Dictionary<string, Items> {
            { "Schaden Trank", new Items('S',0.25, 3) },
            { "Kleiner Lebenspunkte Trank", new Items('H', 50, 1) },
            { "Großer Lebenspunkte Trank", new Items('H', 100, 1) }
        };

        //Waffen
        public static Dictionary<string, Weapons> weapons = new Dictionary<string, Weapons>
        {
            {"Legendaeres Schwert", new Weapons('S', 0.75, "Legendär") },
            {"Kampfaxt", new Weapons('A', 0.5, "Episch") },
            {"Alte Armbrust", new Weapons('B', 0.25, "Selten") }
        };

        //Gegner
        public static Dictionary<string, Enemy> enemy = new Dictionary<string, Enemy>
        {
            {"Ork", new Enemy('O', 500, 100, 45) },
            {"Riese", new Enemy('R', 1500, 250, 20) },
            {"Kobold", new Enemy('K', 250, 10, 90) }
        };

        //Inventar
        public static Dictionary<string, Dictionary<string, int>> inventory = new Dictionary<string, Dictionary<string, int>> 
        {
            {"Items", new Dictionary<string, int>()},
            {"Weapons", new Dictionary<string, int>()}
        };
        public static bool alive = true;
        static void Main(string[] args)
        {
            /* Programm:
             * - Startscreen
             * - (UI)
             * - Objekte:
             *  > Spieler
             *  > Feinde
             *  > Waffen
             * - Kampf-System
             */

            // Standartwaffe
            inventory["Weapons"].Add("Alte Armbrust", 1);

            Menu.VisualMenu();
            Console.Clear();


            Preparation.PepareGame();
            Console.Clear();

            // Schleife für das Spiel
            do
            {
                /* Inhalt:
                 * - Erkunden (Generiert Gegner, Waffe oder Item| Erholungszug)
                 * - Kämpfen (Anzeigen der Stats von Spieler und Gegner)
                 * - Fliehen
                 * - Untersuchen (Ausgabe der Stats von Waffen und Items)
                 */
                Console.Clear();

                Console.WriteLine("Was möchten Sie tun?\n1. Erkunden\n2. Waffe wechseln\n3. Inventar anzeigen\n4. Erholen\n5. Item verwenden");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Actions.Explore();
                        break;
                    case "2":
                        Actions.ChangeWeapon();
                        break;
                    case "3":
                        Console.WriteLine("Inventar:");
                        foreach (var category in inventory)
                        {
                            Console.WriteLine($"\n{category.Key}:");
                            foreach (var item in category.Value)
                            {
                                Console.WriteLine($"- {item.Key} (Anzahl: {item.Value})");
                            }
                        }
                        Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Du erholst dich und deine Rüstung wird um 100 erhöht.");
                        Preparation.P1.setArmorp(Preparation.P1.getArmorp() + 100);
                        break;
                    case "5":
                        Actions.UseItem();
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
                        break;
                }
            } while (alive);

            // Spielende
            Preparation.GameOver();
        }
    }
}
