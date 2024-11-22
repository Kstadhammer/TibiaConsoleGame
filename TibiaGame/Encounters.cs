namespace TibiaGame
{
    public class Encounters
    {
        static Random rand = new Random();

        public static void FirstEncounter()
        {
            Console.WriteLine(
                "With desperate courage, you burst through the door, your hands finding a rusty iron rod. Your muscles tense as you charge at your unsuspecting captor"
            );
            Console.WriteLine(
                "The figure whirls around, revealing its grotesque features in the torchlight..."
            );
            Console.ReadKey();
            Combat(false, "Orc Warrior", 1, 4);
        }

        public static void FightEncounterBasic()
        {
            Console.Clear();
            Console.WriteLine(
                "The ancient corridor stretches before you, and in the dancing shadows, a menacing silhouette emerges"
            );
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }

        public static void FeruEncounter()
        {
            Console.Clear();
            Console.WriteLine(
                $"The massive oak door creaks open, revealing a chamber bathed in ethereal light. Within stands an imposing figure, his wide-brimmed hat casting dark shadows across his face, his silver beard flowing like liquid moonlight"
            );
            Console.WriteLine(
                "Before him floats an ancient grimoire, its pages turning by unseen forces."
            );
            Console.WriteLine(
                "Your blood runs cold as recognition dawns - the legendary archmage Ferumbras himself stands before you!"
            );
            Console.ReadKey();
            Combat(false, "Ferumbras", 4, 2);
        }

        public static void RandomEncounter()
        {
            switch (rand.Next(0, 2))
            {
                case 0:
                    FightEncounterBasic();
                    break;
                case 1:
                    FeruEncounter();
                    break;
            }
        }

        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;

            if (random)
            {
                n = Monsters.GetMonsterNames();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine($"{p} / {h}");
                Console.WriteLine("=====================");
                Console.WriteLine("| [A]ttack [D]efend |");
                Console.WriteLine("| [R]un    [H]eal   |");
                Console.WriteLine("=====================");
                Console.WriteLine(
                    $"Potions: {Program.currentPlayer.potion} Health: {Program.currentPlayer.health}"
                );
                string input = Console.ReadLine();

                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    Console.WriteLine(
                        $"Your blade flashes in the dim light as you surge forward with deadly intent. The {n} meets your charge with savage fury"
                    );

                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack =
                        p - rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);

                    Console.WriteLine(
                        $"The fierce exchange leaves you wounded for {damage} health, but your strike deals {attack} damage"
                    );
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    Console.WriteLine(
                        $"You raise your blade in a defensive stance, carefully watching as the {n} circles you with predatory grace"
                    );

                    int damage = (p / 4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = p - rand.Next(0, Program.currentPlayer.weaponValue) / 2;

                    Console.WriteLine(
                        $"Your cautious strategy results in only {damage} damage taken, while you manage to counter for {attack} damage"
                    );
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine(
                            $"As you turn to flee, the {n} strikes with lightning speed, its attack sending you crashing against the cold stone walls"
                        );

                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine(
                            $"The brutal blow deals {damage} damage, and your escape attempt fails"
                        );
                        Console.ReadKey();
                        Shop.LoadShop(Program.currentPlayer);
                    }
                    else
                    {
                        Console.WriteLine(
                            $"With nimble footwork, you dodge the {n}'s lunging attack and sprint into the darkness beyond"
                        );
                        Console.ReadKey();
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine(
                            "Your hands frantically search your potion belt, finding nothing but empty vials."
                        );
                        Console.WriteLine("By the gods, you're out of healing draughts!");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }

                        Console.WriteLine(
                            $"The {n} seizes upon your moment of desperation, landing a devastating blow for {damage} damage!"
                        );
                    }
                    else
                    {
                        Console.WriteLine(
                            "Your fingers close around a crystal vial filled with shimmering emerald liquid"
                        );

                        int potionValue = 5;
                        Console.WriteLine(
                            "The healing draught courses through your veins like liquid fire!"
                        );
                        Console.WriteLine($"The magical elixir restores {health} health");
                        Program.currentPlayer.health += potionValue;
                        Console.WriteLine(
                            $"However, the {n} interrupts your moment of relief with a vicious strike"
                        );
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine(
                            $"The attack tears through your defenses for {damage} damage"
                        );
                    }

                    Console.ReadKey();
                }

                if (Program.currentPlayer.health <= 0)
                {
                    Console.WriteLine(
                        $"The {n}'s final strike comes with terrifying speed. As darkness claims your vision, the last thing you hear is the creature's triumphant roar echoing through the ancient halls"
                    );
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
            int coins = Program.currentPlayer.GetCoins();

            Console.WriteLine(
                $"As your foe falls, you discover a pouch containing {coins} gleaming gold coins among its possessions."
            );
            Console.WriteLine($"The weight of {coins} coins makes your coin purse heavier.");
            Program.currentPlayer.coins += coins;
            Console.ReadKey();
        }
    }
}
