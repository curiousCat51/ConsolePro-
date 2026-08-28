using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    internal class Help
    {
        public static void h()
        {
            Console.WriteLine("You are choosing the action you want to use against your opponent");
            Console.Write("Options:\n- rock\n- paper\n- scissors");
        }
    }
}
