using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C
{
    internal class Enemy
    {
        private string name;
        private double healthp = 0.0;
        private double armorp = 0.0;
        private double damage = 0.0;

        /* Enemy:
         * - Lebenspunkte
         * - Klassen
         * - Rüstung
         * - Schaden
         */
        public Enemy(string name, double healthp, double armorp, double damage)
        {
            this.name = name;
            this.healthp = healthp;
            this.armorp = armorp;
            this.damage = damage;
        }

        public string getName() { return name; }
        public void setName(string name) { this.name = name; }
        public double getHealthp() { return healthp; }
        public void setHealthp(double healthp) { this.healthp = healthp; }
        public double getArmorp() {return armorp; }
        public void setArmorp(double armorp) { this.armorp = armorp;}
        public double getDamage() { return damage; }
        public void setDamage(double damage) {this.damage = damage;}
    }
}
