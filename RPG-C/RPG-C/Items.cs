using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C
{
    internal class Items
    {
        private char type = '-';
        private double effect = 0.0;
        private int duration = 0;

        /* Items:
         * - Typ
         * - Effekt
         * - Zeitraum
         */
        public Items(char type, double effect, int duration)
        {
            this.type = type;
            this.effect = effect;
            this.duration = duration;
        }

        public char getType(){ return type; }
        public void setType(char type) { this.type = type; }
        public double getEffect() { return effect; }
        public void setEffect(double effect) { this.effect = effect; }

        public int getDuration() { return duration; }
        public void setDuration(int duration) { this.duration = duration; }
    }
}
