using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RPG_C
{
    internal class Actions
    {
        public Actions()
        {

        }

        public static void Explore()
        {
            Console.Clear();
            Console.Title = "Erkunden";
            // Mit hilfe von Random Aktionen wie Gegner, Waffe, Item erscheinen lassen oder alternativ nichts passiert (recovery)
            int result = Generate.NewRandom(4);

            // Auf Basis der Random Zahl, Gegner, Waffe, Item oder nichts passiert (recovery) ausführen
            switch (result)
            {
                case 0:
                {
                    // Gegner erscheint und Kampf wird gestartet
                    Fight();
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
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
            Console.Clear();
        }

        public static int effectTurns = 0;

        public static void Fight()
        {
            int result = Generate.NewRandom(Program.enemy.Count);

            string enemyClassName = Program.enemy.Keys.ElementAt(result);
            double[] enemyStats = new double[]
            {
                Program.enemy[Program.enemy.Keys.ElementAt(result)].getHealthp(),
                Program.enemy[Program.enemy.Keys.ElementAt(result)].getArmorp(),
                Program.enemy[Program.enemy.Keys.ElementAt(result)].getDamage()
            };

            string playerName = Preparation.P1.getName();
            double[] playerStats = new double[]
            {
                Preparation.P1.getHealthp(),
                Preparation.P1.getArmorp(),
                Preparation.P1.getDamage()
            };
            string playerWeapon = Preparation.P1.getHand();

            bool playerTurn = true;
            string choice;
            bool validChoice;
            int valChoice;


            Console.Clear();
            // Anzeige der Möglickeiten (Angriff, Verteidigung, Item benutzen, Fliehen)
            Console.WriteLine($"Ein {enemyClassName} erscheint!");

            BattleStats(playerName, enemyClassName, enemyStats, playerStats, playerWeapon);
            Menu.BattleMenu();

            do
            {
                
                if (playerTurn)
                {
                    do
                    {
                        choice = Console.ReadLine();

                        if (int.TryParse(choice, out valChoice) && valChoice < 1 || valChoice > 4)
                        {
                            Console.WriteLine("Ungültige Eingabe. Bitte wähle eine Zahl zwischen 1 und 4.");
                            valChoice = Convert.ToInt32(Console.ReadLine());
                            validChoice = false;
                        }
                        else
                        {
                            validChoice = true;
                        }
                    }while(!validChoice);


                    if (valChoice == 1)
                    {
                        // Angriff
                        Console.WriteLine($"\nDu greifst den {enemyClassName} an und verursachst {playerStats[2]} Schaden!");
                        if (playerStats[2] > enemyStats[1] && enemyStats[1] != 0)
                        {
                            enemyStats[0] -= (playerStats[2] - enemyStats[1]);
                            enemyStats[1] = 0;
                        }
                        else
                        {
                            if(enemyStats[1] == 0)
                            {
                                enemyStats[0] -= playerStats[2];
                            }
                            else
                            {
                                enemyStats[1] -= playerStats[2];
                            }
                                
                        }
                    }
                    else if (valChoice == 2)
                    {
                        // Verteidigung
                        Console.WriteLine("\nDu verteidigst dich und erhöhst deine Rüstung um 5!");
                        playerStats[1] += 5;
                    }
                    else if (valChoice == 3)
                    {
                        // Item benutzen
                        Console.WriteLine("\nWähle ein Item aus deinem Inventar, das du benutzen möchtest (Nummer):");
                        UseItem();
                    }
                    else if (valChoice == 4)
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
                            playerStats[0] -= enemyStats[2];
                        }

                        Preparation.P1.setHealthp(playerStats[0]);
                    }

                    // Effektdauer verringern und Effekt entfernen, wenn die Dauer abgelaufen ist
                    if (effectTurns > 0)
                    {
                        effectTurns--;
                        if(effectTurns == 0)
                        {
                            playerStats[2] -= Program.items[Program.inventory["Items"].Keys.ElementAt(valChoice - 1)].getEffect();
                            Console.WriteLine("Der Effekt des Items ist abgelaufen.");
                        }
                    }
                }
                else
                {
                    // Gegnerischer Angriff
                    if (enemyStats[2] > playerStats[1] && playerStats[1] != 0)
                    {
                        playerStats[0] -= (enemyStats[2] - playerStats[1]);
                        playerStats[1]= 0;
                    }
                    else
                    {
                        if (playerStats[1] >= 0)
                        {
                            playerStats[0] -= enemyStats[2];
                        }
                        else
                        {
                            playerStats[1] -= enemyStats[2];
                        }
                           
                    }

                    Preparation.P1.setHealthp(playerStats[0]);
                    Preparation.P1.setArmorp(playerStats[1]);

                    Console.WriteLine($"\nDer {enemyClassName} greift dich an und verursacht {enemyStats[2]} Schaden!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    BattleStats(playerName, enemyClassName, enemyStats, playerStats, playerWeapon);
                    Menu.BattleMenu();
                }
                playerTurn = !playerTurn;
            } while (enemyStats[0] > 0 && playerStats[0] > 0);

            Console.WriteLine("Sie haben den Kampf gewonnen");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Examine(int result, int type)
        {
            Console.Title = "Untersuchen";
            Console.Clear();
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
            Console.ReadKey();
            Console.Clear();
        }

        public static void UseItem()
        {
            Console.Title = "Item benutzen";
            Console.Clear();
            string input;
            int itemIndex;

            if (Program.inventory["Items"].Count == 0){
                Console.WriteLine("\nKeine Items im Inventar");
            }
            else
            {
                for(int i = 1; i <= Program.inventory["Items"].Count; i++)
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
                if (Program.items[Program.inventory["Items"].Keys.ElementAt(itemIndex)].getName() == "S")
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
            Console.ReadKey();
            Console.Clear();
        }

        public static void ChangeWeapon()
        {
            Console.Title = "Waffe wechseln";
            Console.Clear();
            // Ändert die Waffe in der Hand des Spielers
            string input;
            int itemIndex;
            for (int i = 0; i < Program.inventory["Weapons"].Count; i++)
            {
                string itemName = Program.inventory["Weapons"].Keys.ElementAt(i);
                int itemCount = Program.inventory["Weapons"][itemName];
                Console.WriteLine($"{i + 1}. {itemName} (Anzahl: {itemCount})");
            }
            do
            {
                do
                {
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out itemIndex));
            } while (itemIndex < 0 || itemIndex > Program.inventory["Weapons"].Count);

            Preparation.P1.setHand(Program.inventory["Weapons"].Keys.ElementAt(itemIndex - 1));

            Console.Clear();
        }

        public static void ShowStats()
        {
            Console.Title = "Stats";
            Console.Clear();
            Console.WriteLine(
                $"Name: {Preparation.P1.getName()}" +
                $"\nGesundheit: {Preparation.P1.getHealthp()}" +
                $"\nRüstung: {Preparation.P1.getArmorp()}" +
                $"\nSchaden: {Preparation.P1.getDamage()}" +
                $"\nWaffe in der Hand: {Preparation.P1.getHand()}");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowInventory()
        {
            Console.Title = "Inventar";
            Console.Clear();
            Console.WriteLine("Inventar:");
            foreach (var category in Program.inventory)
            {
                Console.WriteLine($"\n{category.Key}:");
                foreach (var item in category.Value)
                {
                    Console.WriteLine($"- {item.Key} (Anzahl: {item.Value})");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static void Recover()
        {
            Console.Title = "Erholung";
            Console.Clear();
            Preparation.P1.setArmorp(Preparation.P1.getArmorp() + 5);
            Console.WriteLine("Du erholst dich und deine Rüstung wird um 5 erhöht.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void BattleStats(string playerName, string enemyClassName, double[] enemyStats, double[] playerStats, string playerWeapon)
        {
            Console.WriteLine(
                $"\n{playerName}" +
                $"\nHP: {playerStats[0]}" +
                $"\nAP: {playerStats[1]}" +
                //$"\nMana: {playerStats[3]}" +
                $"\n Weapon: {playerWeapon}" +
                $"\n\n" +
                $"\n{enemyClassName}" +
                $"\nHP: {enemyStats[0]}" +
                $"\nAP: {enemyStats[1]}" +
                //$"\nMana: {enemyStats[3]}" +
                $"\n-----------------------------------" +
                $"\n");
        }
    }
}
