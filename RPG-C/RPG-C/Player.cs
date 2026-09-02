using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C
{
    internal class Player
    {
        private string name = "";
        private string hand = "";
        private double healthp = 0.0;
        private double armorp = 0.0;
        private double damage = 0.0;

        /* Player:
         * - Name
         * - Lebenspunkte
         * - Rüstung
         * - (Mana)
         * - Schaden
         * - Hand
         */
        public Player(string name, double heatlhp, double armorp, double damage, string hand)
        {
            this.name = name;
            this.healthp = heatlhp;
            this.armorp = armorp;
            this.damage = damage;
            this.hand = hand;
        }

        public string getName() { return name; }
        public void setName(string name) { this.name = name; }
        public string getHand() { return hand; }
        public void setHand(string hand) { this.hand = hand; }
        public double getHealthp() { return healthp; }
        public void setHealthp(double healthp) { this.healthp = healthp; }
        
        public double getArmorp() {return armorp; }
        public void setArmorp(double armorp) { this.armorp = armorp; }

        public double getDamage() { return damage; }
        public void setDamage(double damage) { this.damage = damage; }
    }
}
