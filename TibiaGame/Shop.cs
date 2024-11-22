using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TibiaGame
{
    public class Shop
    {
        public static int armorMod;
        public static int weaponMod;
        public static int chMod;

        public static void LoadShop(Player player)
        {
            RunShop(player);
        }

        public static void RunShop(Player player)
        {
            int potionPrice;
            int weaponPrice;
            int armorPrice;
            int chmodPrice;

            while (true)
            {
                potionPrice = 20 + 10 * player.mods;
                weaponPrice = 100 * player.weaponValue;
                armorPrice = 100 * player.armorValue + 1;
                chmodPrice = 300 * player.mods;
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine("       Shop Menu       ");
                Console.WriteLine("=======================");
                Console.WriteLine($"| [A]rmor       ${armorPrice, 6}  |");
                Console.WriteLine($"| [C]hallenge   ${chmodPrice, 6}  |");
                Console.WriteLine($"| [P]otion      ${potionPrice, 6} |");
                Console.WriteLine($"| [W]eapon      ${weaponPrice, 6} |");
                Console.WriteLine("| [E]xit               |");
                Console.WriteLine("=======================");

                Console.WriteLine("=======================");
                Console.WriteLine($"    {player.name}'s Stats    ");
                Console.WriteLine("=======================");
                Console.WriteLine($"| Current Health:   {player.health, 6} |");
                Console.WriteLine($"| Current Coins:    {player.coins, 6} |");
                Console.WriteLine($"| Armor Toughness:  {player.armorValue, 6} |");
                Console.WriteLine($"| Challenge Mods:   {player.mods, 6} |");
                Console.WriteLine($"| Potions Total:    {player.potion, 6} |");
                Console.WriteLine($"| Weapon Strength:  {player.weaponValue, 6} |");
                Console.WriteLine("=======================");

                string input = Console.ReadLine();
                if (input == "a" || input == "armor")
                {
                    TryBuy("potion", potionPrice, player);
                }
                else if (input == "c" || input == "challenge")
                {
                    TryBuy("challenge", chmodPrice, player);
                }
                else if (input == "p" || input == "potion")
                {
                    TryBuy("armor", armorPrice, player);
                }
                else if (input == "w" || input == "weapon")
                {
                    TryBuy("weapon", weaponPrice, player);
                }
                else if (input == "e" || input == "exit")
                {
                    break;
                }
            }
        }

        static void TryBuy(string item, int cost, Player player)
        {
            if (player.coins >= cost)
            {
                if (item == "potion")
                {
                    player.potion++;
                }
                else if (item == "weapon")
                {
                    player.weaponValue++;
                }
                else if (item == "armor")
                {
                    player.armorValue++;
                }
                else if (item == "challenge")
                {
                    player.mods++;
                }
                player.coins -= cost;
            }
            else
            {
                Console.WriteLine("You don't have enough gold for the purchase!");
                Console.ReadKey();
            }
        }
    }
}
