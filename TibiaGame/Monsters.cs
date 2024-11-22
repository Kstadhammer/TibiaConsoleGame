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
                "Amazon",
                "Barbarian Brutetamer",
                "Barbarian Headsplitter",
                "Barbarian Skullhunter",
                "Chakoya Toolshaper",
                "Chakoya Tribewarden",
                "Chakoya Windcaller",
                "Corym Charlatan",
                "Crazed Beggar",
                "Dark Apprentice",
                "Dark Magician",
                "Dark Monk",
                "Deepling Worker",
                "Dwarf",
                "Dworc Fleshhunter",
                "Dworc Venomsniper",
                "Dworc Voodoomaster",
                "Elf",
                "Elf Arcanist",
                "Feverish Citizen",
                "Gang Member",
                "Gladiator",
                "Goblin Assassin",
                "Goblin Scavenger",
                "Grave Robber",
                "Insectoid Scout",
                "Little Corym Charlatan",
                "Lizard Templar",
                "Mad Scientist",
                "Merlkin",
                "Minotaur",
                "Nomad",
                "Novice of the Cult",
                "Orc",
                "Orc Rider",
                "Pirate Ghost",
                "Pirate Marauder",
                "Pirate Skeleton",
                "Poacher",
                "Rorc",
                "Skeleton Warrior",
                "Tarnished Spirit",
                "Valkyrie",
                "Witch",
            };

            Random rand = new Random();
            return monsters[rand.Next(monsters.Count)];
        }
    }
}
