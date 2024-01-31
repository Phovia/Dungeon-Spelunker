using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dungeon_Spelunker
{
    public class Encounter
    {
        static Random rand = new Random();
        //Encounter Generic


       //Encounter
       public static void FirstEncounter()
        {
            Console.WriteLine("The enemy charges at you!");
            Console.ReadLine();
            Combat(false, "Krawler", 1, 5);
        }
        public static void BasicFightEncounter()
        {
            Console.WriteLine("As you walk through the darkness of the dungeon you are ambushed!");
            Console.ReadLine();
            Combat(true,"",0,0);
        }
        public static void LapisGuardianEncounter()
        {
            Console.WriteLine("You open a large chamber like area inside the dungeon, in the very center of it stands a monolit of Lapis Lazuli.");
            Console.WriteLine("Before you know what going on the monolit springs to life turning into a hulking beast made of the presious blue stone");
            Console.WriteLine("The Lapis Guardian lifts its mighty fist and strikes!");
            Combat(false, "The Lapis Guardian", 5, 12);
        } 

       //Encounter tools
       public static void RandomEncounter()
        {
            switch (rand.Next(0, 2))
            {
                case 0:
                    BasicFightEncounter();
                    break;
                case 1:
                    LapisGuardianEncounter();
                    break;
            }
        }
       public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("----------------------");
                Console.WriteLine("||(A)ttack | (G)uard||");
                Console.WriteLine("||(E)scape | (M)end ||");
                Console.WriteLine("----------------------");
                Console.WriteLine(" Potions: " +Program.currentPlayer.potion+"  Vitality: "+Program.currentPlayer.health);

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string input = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (input.Equals("a", StringComparison.CurrentCultureIgnoreCase) || input.Equals("attack", StringComparison.CurrentCultureIgnoreCase))

                {
                    //Attack
                    Console.WriteLine("You attacked the  " + n + " , however the  " + n + "'s strike back with double the force.");
                    int damage = p - Program.currentPlayer.armourValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);

                    Console.WriteLine("You deal " + attack + "  however take " + damage + " from " + n + "'s  firce strikes.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.Equals("g", StringComparison.CurrentCultureIgnoreCase) || input.Equals("gaurd", StringComparison.CurrentCultureIgnoreCase))
                {
                    //Guard
                    Console.WriteLine("As the " + n + "  strikes, you ready yourself for the hit.");
                    int damage = (p/4) - Program.currentPlayer.armourValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);
                    Console.WriteLine("You take " + damage + " from the " + n + " firce strike.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                
                else if (input.Equals("e", StringComparison.CurrentCultureIgnoreCase) || input.Equals("espace", StringComparison.CurrentCultureIgnoreCase))
                {
                    
                    if (rand.Next(0, 2) == 0)

                    {
                        Console.WriteLine("As you try to escape from the  " + n + " , it strikes you in the back");
                        int damage = p - Program.currentPlayer.armourValue;
                        if (damage < 0)
                            damage = 0;
                        else
                        {
                            Console.WriteLine("You manage to espace  " + n + "  with your life and run to the market outside the dungeon.");
                            Console.ReadLine();
                            Market.LoadMarket(Program.currentPlayer);
                        }
                        Console.WriteLine("You lose  " + damage + "  vitality and are unable to escape.");
                    }
                }

                else if (input.Equals("m", StringComparison.CurrentCultureIgnoreCase) || input.Equals("mend", StringComparison.CurrentCultureIgnoreCase))
                {
                    //Mend
                    if (Program.currentPlayer.potion== 0)
                    {
                        Console.WriteLine("You check your pockets yet you notice there are no potions left");
                        int damage = p - Program.currentPlayer.armourValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("The " + n + " attacks you and deals " + damage + " to you!");
                    }
                    else
                    {
                        Console.WriteLine("You reach into your pocket and pull out a potion");
                        int potionV = 5;
                        Console.WriteLine("You gain " + potionV + " vitality");
                        Program.currentPlayer.health += potionV;
                        Console.WriteLine("While you used your time to heal the " + n + "  attacks you");
                        int damage = (p / 2) - Program.currentPlayer.armourValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " vitality");

                    }
                    Console.ReadLine();
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
               if (Program.currentPlayer.health <= 0)
                {
                    //Death Code
                    Console.WriteLine("As the " + n + " strikes you one final time everything turns dark.");
                    Console.WriteLine("The Burrows have taken yet another soul.");
                    Console.ReadLine();
                    System.Environment.Exit(0);
                }
                Console.ReadLine();

            }
            int g = Program.currentPlayer.GetGems();
            Console.WriteLine("As you stand there over the body of " + n + " you cut open it's stomach and proceed to take out "+g+" .");
            Program.currentPlayer.gems += g;
            Console.ReadLine();
        }

        public static string GetName()
        {
            switch (rand.Next(1, 10))
            {
                case 0:
                    return "Krawler";
                case 1:
                    return "Gaslit Spider";
                case 2:
                    return "Corpse of the Damned Spelunker";
                case 3:
                    return "Gobbler";
                case 4:
                    return "Hellsnare";
                case 5:
                    return "Hound";
                case 6:
                    return "Greiving Hound";
                case 7:
                    return "Hell Hound";
                case 8:
                    return "Abyss Stakler";
            }
            return "Crazed Spelunker";
        }
    }
}
