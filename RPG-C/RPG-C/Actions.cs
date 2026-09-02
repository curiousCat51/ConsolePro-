using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RPG_C
{
    internal class Actions
    {
        public Actions()
        {

        }

        public static void Explore()
        {
            // Mit hilfe von Random Aktionen wie Gegner, Waffe, Item erscheinen lassen oder alternativ nichts passiert (recovery)
            int result = Generate.NewRandom(4);

            // Auf Basis der Random Zahl, Gegner, Waffe, Item oder nichts passiert (recovery) ausführen
            switch (result)
            {
                case 0:
                {
                    // Gegner erscheint
                    result = Generate.NewRandom(3);
                    // Liest die Informationen aus dem Objekt aus und übergibt diese an die Fight Methode
                    Fight(enemyClass: Program.enemy.Keys.ElementAt(result), health: Program.enemy[Program.enemy.Keys.ElementAt(result)].getHealthp(), armor: Program.enemy[Program.enemy.Keys.ElementAt(result)].getArmorp(), damage: Program.enemy[Program.enemy.Keys.ElementAt(result)].getDamage());
                    break;
                }
                case 1:
                {
                    // Waffe erscheint
                    result = Generate.NewRandom(3);
                    bool done = true;

                    Console.WriteLine("Eine Waffe erscheint, was möchten Sie tun?");
                    do
                    {
                        Console.WriteLine("\n1 genauer Betrachten\n2 aufnehmen\n3 liegen lassen oder abbrechen");
                        // Betrachten, aufnehmen oder liegen lassen (recovery) der Waffe
                        string choice = Console.ReadLine();
                        if(choice == "1")
                        {
                            Examine(result, 1);
                        }
                        else if(choice == "2")
                        {
                            Program.inventory["Weapons"].Add(Program.weapons.Keys.ElementAt(result), 1);
                            Console.WriteLine("Waffe wurde dem Inventar hinzugefügt.");
                            done = false;
                        }
                        else
                        {
                            done = false;
                        }
                    } while (done);
                    break;
                }
                case 2:
                {
                    // Item erscheint
                    result = Generate.NewRandom(3);
                    bool done = true;

                    Console.WriteLine("Ein Item erscheint, was möchten Sie tun?");
                    do
                    {
                        Console.WriteLine("\n1 genauer Betrachten\n2 aufnehmen\n3 liegen lassen oder abbrechen");
                        // Betrachten, aufnehmen oder liegen lassen (recovery) des Items
                        string choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            Examine(result, 2);
                        }
                        else if (choice == "2")
                        {
                            // Überprüfen, ob das Item bereits im Inventar ist, wenn ja, erhöhen Sie die Anzahl, andernfalls fügen Sie es hinzu
                            if (Program.inventory["Items"].ContainsKey(Program.items.Keys.ElementAt(result)))
                            {
                                Program.inventory["Items"][Program.items.Keys.ElementAt(result)]++;
                            }
                            else
                            {
                                Program.inventory["Items"].Add(Program.items.Keys.ElementAt(result), 1);
                            }
                            Console.WriteLine("\nItem wurde dem Inventar hinzugefügt.");
                                done = false;
                        }
                        else
                        {
                            done = false;
                        }
                    } while (done);
                    break;
                }
                default:
                {
                    // Nichts passiert (recovery)
                    Console.WriteLine("\nNichts passiert, du erholst dich.");
                    Preparation.P1.setArmorp(Preparation.P1.getArmorp() + 5);
                    break;
                }
            }
        }

        public static int effectTurns = 0;

        public static void Fight(string enemyClass, double health, double armor, double damage)
        {
            string enemyClassName = enemyClass;
            double enemyHealth = health;
            double enemyArmor = armor;
            double enemyDamage = damage;
            string playerName = Preparation.P1.getName();
            double playerHealth = Preparation.P1.getHealthp();
            double playerArmor = Preparation.P1.getArmorp();
            double playerDamage = Preparation.P1.getDamage();
            string playerWeapon = Preparation.P1.getHand();

            bool playerTurn = true;
            int choice;
            

            // Anzeige der Möglickeiten (Angriff, Verteidigung, Item benutzen, Fliehen)
            Console.Clear();
            Console.WriteLine($"Ein {enemyClassName} erscheint!");

            do
            {
                Preparation.VisualMenu(playerName, enemyClassName, playerHealth, enemyHealth, playerArmor, enemyArmor, playerWeapon);
                if (playerTurn)
                {
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        // Angriff
                        Console.WriteLine($"\nDu greifst den {enemyClassName} an und verursachst {playerDamage} Schaden!");
                        if (playerDamage > enemyArmor && enemyArmor != 0)
                        {
                            enemyHealth -= (playerDamage - enemyArmor);
                            enemyArmor = 0;
                        }
                        else
                        {
                            if(enemyArmor == 0)
                            {
                                enemyHealth -= playerDamage;
                            }
                            else
                            {
                                enemyArmor -= playerDamage;
                            }
                                
                        }
                    }
                    else if (choice == 2)
                    {
                        // Verteidigung
                        Console.WriteLine("\nDu verteidigst dich und erhöhst deine Rüstung um 5!");
                        playerArmor += 5;
                    }
                    else if (choice == 3)
                    {
                        // Item benutzen
                        Console.WriteLine("\nWähle ein Item aus deinem Inventar, das du benutzen möchtest (Nummer):");
                        UseItem();
                    }
                    else if (choice == 4)
                    {
                        // Fliehen + Chance nochmals getroffen zu werden
                        int fleeChance = Generate.NewRandom(1);
                        if (fleeChance == 0)
                        {
                            Console.WriteLine("\nDu bist erfolgreich geflohen!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nDu bist beim Fliehen getroffen worden!");
                            playerHealth -= enemyDamage;
                        }

                        Preparation.P1.setHealthp(playerHealth);
                    }

                    // Effektdauer verringern und Effekt entfernen, wenn die Dauer abgelaufen ist
                    if (effectTurns > 0)
                    {
                        effectTurns--;
                        if(effectTurns == 0)
                        {
                            playerDamage -= Program.items[Program.inventory["Items"].Keys.ElementAt(choice - 1)].getEffect();
                            Console.WriteLine("Der Effekt des Items ist abgelaufen.");
                        }
                    }
                }
                else
                {
                    // Gegnerischer Angriff
                    if(enemyDamage > playerArmor && playerArmor != 0)
                    {
                        playerHealth -= (enemyDamage - playerArmor);
                        playerArmor = 0;
                    }
                    else
                    {
                        if(playerArmor == 0)
                        {
                            playerHealth -= enemyDamage;
                        }
                        else
                        {
                            playerArmor -= enemyDamage;
                        }
                           
                    }

                    Preparation.P1.setHealthp(playerHealth);
                    Preparation.P1.setArmorp(playerArmor);

                    Console.WriteLine($"\nDer {enemyClassName} greift dich an und verursacht {enemyDamage} Schaden!");
                }
                playerTurn = !playerTurn;
            } while(enemyHealth > 0 && playerHealth > 0);

            Console.WriteLine("Sie haben den Kampf gewonnen");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Examine(int result, int type)
        {
            // Items und Waffen untersuchen
            if(type == 1)
            {
                string name = Program.weapons.Keys.ElementAt(result);
                double damage = Program.weapons[Program.weapons.Keys.ElementAt(result)].getDmgAdd();
                string rarity = Program.weapons[Program.weapons.Keys.ElementAt(result)].getRarity();

                Console.WriteLine($"\nName: {name}\nSchaden: {damage}\nSeltenheit: {rarity}");
            }
            else
            {
                string name = Program.items.Keys.ElementAt(result);
                double effect = Program.items[Program.items.Keys.ElementAt(result)].getEffect();
                int duration = Program.items[Program.items.Keys.ElementAt(result)].getDuration();

                Console.WriteLine($"\nName: {name}\nEffekt: {effect}\nEffektdauer: {duration}");
            }
        }

        public static void UseItem()
        {
            string input = "";
            int itemIndex;
            for(int i = 0; i < Program.inventory["Items"].Count; i++)
            {
                string itemName = Program.inventory["Items"].Keys.ElementAt(i);
                int itemCount = Program.inventory["Items"][itemName];
                Console.WriteLine($"{i + 1}. {itemName} (Anzahl: {itemCount})");
            }
            do
            {
                input = Console.ReadLine();
            } while (!int.TryParse(input, out itemIndex));


            // Überprüfen, ob der Index gültig ist und zu welchem Effekttypen das Item gehört (Schaden oder Heilung)
            if (Program.items[Program.inventory["Items"].Keys.ElementAt(itemIndex)].getType() == 'S')
            {
                // Schaden erhöhen
                Preparation.P1.setDamage(Preparation.P1.getDamage() + (Program.items[Program.inventory["Items"].Keys.ElementAt(itemIndex)].getEffect() * Preparation.P1.getDamage())); 
                effectTurns = Program.items[Program.inventory["Items"].Keys.ElementAt(itemIndex)].getDuration();
            }
            else
            {
                // Gesundheit erhöhen
                Preparation.P1.setHealthp(Preparation.P1.getHealthp() + Program.items[Program.inventory["Items"].Keys.ElementAt(itemIndex)].getEffect());
                effectTurns = Program.items[Program.inventory["Items"].Keys.ElementAt(itemIndex)].getDuration();
            }

            // Item aus dem Inventar entfernen
            if (Program.inventory["Items"][Program.inventory["Items"].Keys.ElementAt(itemIndex)] == 1)
            {
                Program.inventory["Items"].Remove(Program.inventory["Items"].Keys.ElementAt(itemIndex));
            }
            else
            {
                Program.inventory["Items"][Program.inventory["Items"].Keys.ElementAt(itemIndex)]--;
            }
        }

        public static void ChangeWeapon()
        {
            // Ändert die Waffe in der Hand des Spielers
            string input = "";
            int itemIndex;
            for (int i = 0; i < Program.inventory["Weapons"].Count; i++)
            {
                string itemName = Program.inventory["Weapons"].Keys.ElementAt(i);
                int itemCount = Program.inventory["Weapons"][itemName];
                Console.WriteLine($"{i + 1}. {itemName} (Anzahl: {itemCount})");
            }
            do
            {
                input = Console.ReadLine();
            } while (!int.TryParse(input, out itemIndex));

            Preparation.P1.setHand(Program.inventory["Weapons"].Keys.ElementAt(itemIndex - 1));
        }
    }
}
