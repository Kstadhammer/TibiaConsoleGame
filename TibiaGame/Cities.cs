using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TibiaGame
{
    public class Cities
    {
        public static string GetRandomCity()
        {
            List<string> cities = new List<string>
            {
                "Thais",
                "Venore",
                "Ab'Dendriel",
                "Carlin",
                "Edron",
                "Kazordoon",
                "Darashia",
                "Ankrahmun",
                "Farmine",
                "Gray Beach",
                "Issavi",
                "Liberty Bay",
                "Port Hope",
                "Rathleton",
                "Roshamuul",
                "Svargrond",
                "Yalahar",
            };

            Random rand = new Random();
            return cities[rand.Next(cities.Count)];
        }
    }
}
