using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    internal class Gen
    {
        public static int RandNumb()
        {
            Random rnd = new Random();
            return rnd.Next(0, 2 + 1);
        }
    }
}
