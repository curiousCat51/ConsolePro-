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
            { "Schadenstrank", new Items("S",0.25, 3) },
            { "Kleiner Heiltrank", new Items("H", 50, 1) },
            { "Großer Heiltrank", new Items("H", 100, 1) },
            { "Mana Trank", new Items("M", 50, 1) },
            { "Rüstungstrank", new Items("R", 0.25, 3) }
        };

        //Waffen
        public static Dictionary<string, Weapons> weapons = new Dictionary<string, Weapons>
        {
            { "Legendäres Ahnen Schwert", new Weapons("Legendäres Ahnen Schwert", 1.0, 2.5, "Legendär")},
            { "Sturmbrecher", new Weapons("Sturmbrecher", 1.2, 1.5, "Episch")},
            { "Alte Armbrust", new Weapons("Alte Armbrust", 0.8, 1.1, "Selten")},
            { "Rostiger Dolch", new Weapons("Rostiger Dolch", 0.6, 1.0, "Gewöhnlich")}
        };

        //Gegner
        public static Dictionary<string, Enemy> enemy = new Dictionary<string, Enemy>
        {
            { "Goblin", new Enemy("Goblin", 500, 50, 50) },
            { "Ork", new Enemy("Ork", 800, 100, 75) },
            { "Troll", new Enemy("Troll", 1200, 150, 100) },
            { "Dämon", new Enemy("Dämon", 1000, 200, 150) },
            { "Drache", new Enemy("Drache", 3000, 250, 200) }
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
            bool success;

            // Standartwaffe
            inventory["Weapons"].Add("Alte Armbrust", 1);

            Menu.GameStart();
            Console.Clear();


            Preparation.CharacterCreation();
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

                do
                {
                    Menu.ActionsMenu();
                    string choice = Console.ReadLine();
                    if(!string.IsNullOrEmpty(choice))
                    {
                        switch (choice)
                        {
                            case "1":
                                Actions.Explore();
                                success = true;
                                break;
                            case "2":
                                Actions.Recover();
                                success = true;
                                break;
                            case "3":
                                Actions.ShowStats();
                                success = true;
                                break;
                            case "4":
                                Actions.ShowInventory();
                                success = true;
                                break;
                            case "5":
                                Actions.ChangeWeapon();
                                success = true;
                                break;
                            case "6":
                                Actions.UseItem();
                                success = true;
                                break;
                            default:
                                Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
                                success = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Die Eingabe darf nicht leer sein. Bitte versuchen Sie es erneut.");
                        success = false;
                    }
                } while (!success);
            } while (alive);

            // Spielende
            Menu.GameOver();
        }
    }
}
