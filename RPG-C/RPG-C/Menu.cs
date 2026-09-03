using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C
{
    internal class Menu
    {
        public Menu()
        {

        }
        public static void GameStart()
        {
            Console.Title = "RPG_C";
            string[] picture = new string[]
            {
                @"  ____________________________________  ",
                @" /                                    \ ",
                @"|                                      |",
                @"|                                      |",
                @"|         Willkommen zu RPG-C          |",
                @"|   Drücke eine Taste um zu beginnen.  |",
                @"|                                      |",
                @"|                                      |",
                @" \____________________________________/ "
            };
               
            for(int i = 0; i < picture.Length; i++)
            {
                Console.WriteLine(picture[i]);
            }

            Console.ReadKey();
        }

        public static void ActionsMenu()
        {
            Console.Title = "RPG_C - Aktionen";
            string[] picture = new string[]
            {
                "1. Erkunden",
                "2. Erholen",
                "3. Spieler Stats anzeigen",
                "4. Inventar anzeigen",
                "5. Waffe wechseln",
                "6. Item verwenden"
            };
            for (int i = 0; i < picture.Length; i++)
            {
                Console.WriteLine(picture[i]);
            }
        }

        public static void BattleMenu()
        {
            Console.Title = "RPG_C - Kampf";

            string[] picture = new string[]
            {
                "1. Angreifen",
                "2. Verteidigen",
                "3. Item benutzen",
                "4. Fliehen"
            };
            for (int i = 0; i < picture.Length; i++)
            {
                Console.WriteLine(picture[i]);
            }
        }

        public static void GameOver()
        {
            Console.Clear();
            string[] picture = new string[]
            {
                @"  ____________________________________  ",
                @" /                                    \ ",
                @"|                                      |",
                @"|                                      |",
                @"|             Game Over!               |",
                @"|   Drücke eine Taste um zu beenden.   |",
                @"|                                      |",
                @"|                                      |",
                @" \____________________________________/ "
            };
            for (int i = 0; i < picture.Length; i++)
            {
                Console.WriteLine(picture[i]);
            }
            Console.ReadKey();
        }
    }
}
