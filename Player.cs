using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Spelunker
{
        public class Player
    {
        Random rand = new Random();

        public string? name;
        public int gems = 30000000;
        public int health = 10;
        public int damage = 1;
        public int armourValue = 0;
        public int potion = 5;
        public int weaponValue = 1;

        public int diffmods = 0;

        public int GetHealth()
        {
            int upper = (2 * diffmods + 5);
            int lower = (diffmods + 2);
            return rand.Next(lower,upper);
        }
        public int GetPower()
        {
            int upper = (2 * diffmods + 3);
            int lower = (diffmods + 1);
            return rand.Next(lower, upper);
        }
        public int GetGems()
        {
            int upper = (15 * diffmods + 50);
            int lower = (10 * diffmods + 10);
            return rand.Next(lower, upper);
        }
    }
}
