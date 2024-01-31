using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dungeon_Spelunker
{
    internal class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainloop = true;
        static void Main(string[] args)
        {
            Start();
            Encounter.FirstEncounter();
            while (mainloop)
            {
                Encounter.RandomEncounter();
            }
        }


        static void Start()
        {
            Console.WriteLine("Welcome to Dungeon Spelunker");
            Console.WriteLine("What is your name?");
            currentPlayer.name = Console.ReadLine();
            Console.WriteLine("World of Tebulta is a haven for spelunkers of all kind as this world has a dungeon");
            Console.WriteLine("known by all as The Dark Burrows were the bravest venture, but only the best return from.");
            Console.WriteLine("The ones that do enter and return alive from the deepest parts of the dungeon");
            Console.WriteLine("are given the title of 'Sages of the Burrows' and recive a special trinket handcrafted for them to show their status of a Sage.");
            Console.WriteLine("Now you are begining your own journey into the depths of the burrows to solidify yourself as the newest Sage of Burrows.");
            Console.WriteLine("Will you come back from the deepest depths and prove that you deserve the title? Or die like many before you?");
            if (currentPlayer.name == "")
                Console.WriteLine("Good luck Stranger.");
            else
                Console.WriteLine("Good luck "+ currentPlayer.name);
            string? v1 = Console.ReadLine();
            string? v = v1;
            Console.WriteLine("You enter the dungeon, as you step foot into the inside of the dungeon you can see a some what small figure roaming about.");
            Console.WriteLine("However it doesn't take long before attacking you.");
        }
    }
}
