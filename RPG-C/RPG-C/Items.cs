using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C
{
    internal class Items
    {
        private string name = "";
        private double effect = 0.0;
        private int duration = 0;

        /* Items:
         * - Typ
         * - Effekt
         * - Zeitraum
         */
        public Items(string name, double effect, int duration)
        {
            this.name = name;
            this.effect = effect;
            this.duration = duration;
        }

        public string getName(){ return name; }
        public void setName(string name) { this.name = name; }
        public double getEffect() { return effect; }
        public void setEffect(double effect) { this.effect = effect; }

        public int getDuration() { return duration; }
        public void setDuration(int duration) { this.duration = duration; }
    }
}
