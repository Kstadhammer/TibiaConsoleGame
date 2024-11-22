using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TibiaGame
{
    public class Monsters
    {
        public static string GetMonsterNames()
        {
            List<string> monsters = new List<string>
            {
                "Wild Warrior",
                "Orc Warrior",
                "Minotaur Archer",
                "Elf Scout",
                "Orc Shaman",
                "Demon Skeleton",
                "Minotaur Mage",
                "Orc Berserker",
                "Fire Devil",
                "Honour Guard",
                "Hunter",
                "Orc Warlord",
                "Smuggler",
                "Mummy",
                "Dwarf Guard",
                "Dwarf Soldier",
                "Assassin",
                "Lizard Sentinel",
                "Minotaur Guard",
                "Monk",
                "Orc Spearman",
            };

            Random rand = new Random();
            return monsters[rand.Next(monsters.Count)];
        }
    }
}
