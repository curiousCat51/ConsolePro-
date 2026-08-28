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
        static void Main(string[] args)
        {
            //Items
            Dictionary<string, Items> items = new Dictionary<string, Items> {
                { "Schaden Trank", new Items('S',0.25, 3) },
                { "Kleiner Lebenspunkte Trank", new Items('H', 50, 1) },
                { "Großer Lebenspunkte Trank", new Items('H', 100, 1) }
            };

            //Waffen
            Dictionary<string, Weapons> weapons = new Dictionary<string, Weapons>
            {
                {"Legendaeres Schwert", new Weapons('S', 0.75, "Legendär") },
                {"Kampfaxt", new Weapons('A', 0.5, "Episch") },
                {"Alte Armbrust", new Weapons('B', 0.25, "Common") }
            };

            //Gegner
            Dictionary<string, Enemy> enemy = new Dictionary<string, Enemy>
            {
                {"Ork", new Enemy('O', 500, 100, 45) },
                {"Riese", new Enemy('R', 1500, 250, 20) },
                {"Kobold", new Enemy('K', 250, 10, 90) }
            };

            //Inventar
            Dictionary<string, List<string>> inventory = new Dictionary<string, List<string>> 
            {
                {"Items", new List<string>()},
                {"Weapons", new List<string>()}
            };

            Player P1 = new Player("Hannibal", 1000, 200, 75);

            /* Programm:
             * - Startscreen
             * - (UI)
             * - Objekte:
             *  > Spieler
             *  > Feinde
             *  > Waffen
             * - Kampf-System
             */

            Menu.VisualMenu();
            Console.Clear();

            // Schleife für das Spiel

            /* Inhalt:
             * - Erkunden
             * - Kämpfen
             * - Fliehen
             * - Untersuchen
             */
        }
    }
}
