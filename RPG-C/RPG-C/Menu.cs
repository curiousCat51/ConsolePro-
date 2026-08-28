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
        public static void VisualMenu()
        {
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
    }
}
