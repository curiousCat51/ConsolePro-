using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C
{
    internal class Generate
    {
        // Generiert zufällige Zahlen für verschiedene Verwendungszwecke

        public Generate()
        {

        }

        public static int NewRandom(int b, int a = 0)
        {
            Random rnd = new Random();
            return rnd.Next(a, b + 1);
        }
    }
}
