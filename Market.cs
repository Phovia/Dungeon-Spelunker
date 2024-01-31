using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Spelunker
{
    public class Market
    {
        public static void LoadMarket(Player p)
        {
            RunMarket(p);
        }
        public static void RunMarket(Player p)
        {
            int potionP;
            int armorP;
            int weaponP;
            int difP;
            while (true)
            {
                potionP = 20 + 10 * p.diffmods;
                armorP = 100 * (p.armourValue + 1);
                weaponP = 100 * p.weaponValue;
                difP = 300 + 100 * p.diffmods + 1;
                Console.WriteLine("         Market           ");
                Console.WriteLine("--------------------------");
                Console.WriteLine("||(W)eapon :             G" + weaponP);
                Console.WriteLine("||(D)efence :             G" + armorP);
                Console.WriteLine("||(P)otion :             G" + potionP);
                Console.WriteLine("||(C)hallange Modifier : G" + difP);
                Console.WriteLine("--------------------------");
                Console.WriteLine("(L)eave");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(p.name + "'s   Stats       ");
                Console.WriteLine("--------------------------");
                Console.WriteLine("Current Vitality"       + p.health);
                Console.WriteLine("Gems"                       + p.gems);
                Console.WriteLine("Weapon Strenght: " + p.weaponValue);
                Console.WriteLine("Armour Toughness " + p.armourValue);
                Console.WriteLine("Potions amount" + p.potion);
                Console.WriteLine("Challenge Modification" + p.diffmods);
                Console.WriteLine("--------------------------");

                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                string input = Console.ReadLine().ToLower();
                #pragma warning restore CS8602 // Dereference of a possibly null reference.
                if (input == "p" || input == "potion")
                {
                    TryBuy("potion", potionP, p);
                }
                else if (input == "w" || input == "weapon")
                {
                    TryBuy("weapon", weaponP, p);
                }
                else if (input == "d" || input == "defence")
                {
                    TryBuy("armour", armorP, p);
                }
                else if (input == "c" || input == "Challange Modifier")
                {
                    TryBuy("challange", difP, p);
                }
                else if (input == "l" || input == "leave")
                break;
            }
        }
        static void TryBuy(string item, int cost, Player p)
        {
            if (p.gems >= cost)
            {
             if (item == "potion")
                p.potion++;
            else if (item == "weapon")
            p.weaponValue++;
            else if (item == "defence")
            p.armourValue++;
            else if (item == "challange")
            p.diffmods++;
             
            p.gems -= cost;

            }
                
            else 
                {
                    Console.WriteLine("If you like to buy this item come back when you are, hmmmm, richer.");
                    Console.ReadLine();
                }
        }
    }
}