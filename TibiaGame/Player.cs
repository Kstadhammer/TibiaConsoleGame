using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TibiaGame
{
    [Serializable]
    public class Player
    {
        private Random rand = new Random();

        public List<string> races = new List<string>();

        public void PlayerRace()
        {
            races.Add("Human");
            races.Add("Elf");
            races.Add("Dwarf");
        }

        public string feruHat = "Ferumbras Hat";
        public string name;
        public int saveID;
        public int coins = 5000;
        public int health = 10;
        public int mana = 5;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int weaponValue = 1;
        public int mods = 0;

        public int GetHealth()
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return rand.Next(lower, upper);
        }

        public int GetPower()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return rand.Next(lower, upper);
        }

        public int GetCoins()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return rand.Next(lower, upper);
        }

        public string GetRandomRace()
        {
            return races[rand.Next(races.Count)];
        }

        public string GetRandomCity()
        {
            return Cities.GetRandomCity();
        }
    }
}
