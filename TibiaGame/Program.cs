using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TibiaGame
{
    class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLop = true;

        static void Main(string[] args)
        {
            Start();
            Encounters.FirstEncounter();
            while (mainLop)
            {
                Encounters.RandomEncounter();
            }
        }

        static void Start()
        {
            Console.WriteLine("Welcome to the world of Tibia.");
            Console.Write("Name: ");
            currentPlayer.name = Console.ReadLine();

            Console.Clear();

            Console.WriteLine(
                "You awake in a cold and dark room. You don't know where you are and you feel a little bit dazed. "
            );

            if (currentPlayer.name == "")
            {
                Console.WriteLine("You can't remember who you are.");
            }
            else
            {
                Console.WriteLine(
                    $"You know your name is {currentPlayer.name} and you are from {currentPlayer.GetRandomCity()} and you are a {currentPlayer.GetRandomRace()}."
                );
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(
                "You are moving slowly in the dark feeling around until you find a door handle. You feel some resistance when turning the handle, "
            );
            Console.WriteLine("the lock is rusty so it breaks with little effort.");
            Console.WriteLine(
                "You see your captor, he's standing with his back towards you, just outside the large door."
            );
        }
    }
}
