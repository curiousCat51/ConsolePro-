using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C
{
    internal class Weapons
    {
        private string name = "";
        private string rarity = "";
        private double dmgAdd = 0.0;
        private double manaMultiplier = 0.0;
        /* Weapon:
         * - Typ
         * - Seltenheit
         * - Schaden multiplikator
         * - Mana multiplikator
         */
        public Weapons(string name, double dmgAdd, double manaMultiplier, string rarity = "Gewöhnlich")
        {
            this.name = name;
            this.dmgAdd= dmgAdd;
            this.manaMultiplier = manaMultiplier;
            this.rarity = rarity;
        }

        public string getName() { return name; }
        public void setName(string name) { this.name = name; }

        public string getRarity() { return rarity; }
        public void setRarity(string rarity) { this.rarity = rarity; }

        public double getDmgAdd() { return dmgAdd; }
        public void setDmgAdd(double dmgMultiplier) { this.dmgAdd= dmgMultiplier; }
        public double getManaMultiplier() {return manaMultiplier; }
        public void setManaMultiplier(double manaMultiplier) { this.manaMultiplier = manaMultiplier; }
    }
}
