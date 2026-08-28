using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Rnd
    {
        public static int Number()
        {
            Random rnd = new Random();
            return rnd.Next(0, Program.Words.Count);
        }
    }
}
