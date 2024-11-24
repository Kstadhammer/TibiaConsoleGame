using System.IO;
using System.Text.Json;

namespace TibiaGame
{
    class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLop = true;

        static void Main(string[] args)
        {
            if (!Directory.Exists("gameaves"))
            {
                Directory.CreateDirectory("gamesaves");
            }
            Start();
            Encounters.FirstEncounter();
            while (mainLop)
            {
                Encounters.RandomEncounter();
            }
        }

        static void Start()
        {
            Console.WriteLine(
                "Welcome to the mystical realm of Tibia, a land shrouded in ancient magic and forgotten legends."
            );
            Console.Write("Speak thy name, brave soul: ");
            currentPlayer.name = Console.ReadLine();

            Console.Clear();

            Console.WriteLine(
                "Consciousness returns slowly, your head throbbing with each heartbeat. The stone chamber around you is pitch black and deathly cold, the musty air heavy with the scent of decay. Your mind struggles to piece together how you came to be here."
            );

            if (currentPlayer.name == "")
            {
                Console.WriteLine(
                    "The fog in your mind refuses to lift - even your own identity remains a mystery lost to the darkness."
                );
            }
            else
            {
                Console.WriteLine(
                    $"Through the haze of confusion, you recall fragments of your identity. You are {currentPlayer.name}, a {currentPlayer.GetRandomRace()} warrior who once called the grand city of {currentPlayer.GetRandomCity()} home."
                );
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(
                "Your trembling hands trace the rough stone walls as you stumble through the darkness. At last, your fingers brush against cold metal - a door handle, its ancient mechanism groaning in protest."
            );
            Console.WriteLine(
                "The lock, weakened by years of rust and neglect, yields to your desperate efforts with a sharp crack."
            );
            Console.WriteLine(
                "As the heavy door creaks open, you glimpse a hooded figure standing motionless in the torchlit corridor beyond. Your captor remains oblivious to your escape, their dark silhouette casting long shadows against the ancient stonework."
            );
        }

        //Save and Load functions, used Claude to fix some errors.

        public static void GameSave()
        {
            string path = "saves/" + currentPlayer.saveID.ToString();
            string json = JsonSerializer.Serialize(currentPlayer);
            File.WriteAllText(path, json);
        }

        public static Player GameLoad()
        {
            Console.Clear();
            Console.WriteLine("Choose a character: ");
            string[] paths = Directory.GetDirectories("saves");
            List<Player> players = new List<Player>();

            foreach (string p in paths)
            {
                string json = File.ReadAllText(p);
                Player player = JsonSerializer.Deserialize<Player>(json);
                players.Add(player);
            }
            foreach (Player p in players)
            {
                Console.WriteLine($"{p.saveID} : {p.name}");
            }
            Console.WriteLine("Please enter your player name or player id.");
        }
    }
}
