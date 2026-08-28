using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C
{
    internal class Weapons
    {
        private char type = '-';
        private string rarity = "";
        private double dmgAdd = 0.0;
        private double manaMultiplier = 0.0;
        /* Weapon:
         * - Typ
         * - Seltenheit
         * - Schaden multiplikator
         * - Mana multiplikator
         */
        public Weapons(char type, double dmgAdd, string rarity = "uncommon")
        {
            this.type = type;
            this.dmgAdd= dmgAdd;
            this.rarity = rarity;
        }

        public char getType() { return type; }
        public void setType(char type) { this.type = type; }

        public string getRarity() { return rarity; }
        public void setRarity(string rarity) { this.rarity = rarity; }

        public double getDmgAdd() { return dmgAdd; }
        public void setDmgAdd(double dmgMultiplier) { this.dmgAdd= dmgMultiplier; }
        public double getManaMultiplier() {return manaMultiplier; }
        public void setManaMultiplier(double manaMultiplier) { this.manaMultiplier = manaMultiplier; }
    }
}
