using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C
{
    internal class Enemy
    {
        private char type = '-';
        private double healthp = 0.0;
        private double armorp = 0.0;
        private double damage = 0.0;

        /* Enemy:
         * - Lebenspunkte
         * - Klassen
         * - Rüstung
         * - Schaden
         */
        public Enemy(char type, double healthp, double armorp, double damage)
        {
            this.type = type;
            this.healthp = healthp;
            this.armorp = armorp;
            this.damage = damage;
        }

        public char getType() { return type; }
        public void setType(char type) { this.type = type; }
        public double getHealthp() { return healthp; }
        public void setHealthp(double healthp) { this.healthp = healthp; }
        public double getArmorp() {return armorp; }
        public void setArmorp(double armorp) { this.armorp = armorp;}
        public double getDamage() { return damage; }
        public void setDamage(double damage) {this.damage = damage;}
    }
}
