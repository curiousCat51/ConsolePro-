using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperatur_Calculator
{
    internal class Converter
    {
        public static double FtoC(double F, out double c)
        {
            c = (F - 32) * 5 / 9;
            return c;
        }
        public static double CtoF(double C, out double f)
        {
            f = (C * 9 / 5) + 32;
            return f;
        }
    }
}
