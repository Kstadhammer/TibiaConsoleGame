namespace TibiaGame
{
    public class Encounters
    {
        static Random rand = new Random();

        public static void FirstEncounter()
        {
            Console.WriteLine(
                "You kick the door open and grab a metal rod while running towards your captor"
            );
            Console.WriteLine("He turns around facing you....");
            Console.ReadKey();
            Combat(false, "Orc Warrior", 1, 4);
        }

        public static void FightEncounterBasic()
        {
            Console.Clear();
            Console.WriteLine("You turn the corner and see something in the distance");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }

        public static void FeruEncounter()
        {
            Console.Clear();
            Console.WriteLine(
                $"The door slowly open in the dark room. You see a tall man with a large had and long beard "
            );
            Console.WriteLine("looking at a large and ancient tome. ");
            Console.WriteLine("You recognize him! It's the might Ferumbras. ");
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
            // n = name
            // p = power
            // h = health
            // c = coins

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
                //Menu options:
                //Attack, Defend, Run and Heal


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
                    //attack

                    Console.WriteLine(
                        $"With great haste you run forward with a sword in your hand. The {n} hits you"
                    );

                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack =
                        p - rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);

                    Console.WriteLine($"You lose {damage} health and deal {attack} damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //defend
                    Console.WriteLine(
                        $"As the {n} prepares to attack, you draw your sword and takes a defensive stance"
                    );

                    int damage = (p / 4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = p - rand.Next(0, Program.currentPlayer.weaponValue) / 2;

                    Console.WriteLine($"You lose {damage} health and deal {attack} damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //run
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine(
                            $"As you run away from {n} it hits you in the back, sending you flying across the room"
                        );

                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine($"You lose {damage} health and you are unable to escape");
                        Console.ReadKey();
                        Shop.LoadShop(Program.currentPlayer);
                    }
                    else
                    {
                        Console.WriteLine($"You evade the attack from {n} and manages to escape");
                        Console.ReadKey();
                        //create a store function
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //heal
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine(
                            "You desperately search your bag for healing potions. But you can't find any."
                        );
                        Console.WriteLine("DAMN!!");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }

                        Console.WriteLine(
                            $"Suddenly {n} strikes you hard and you lose {damage} health! "
                        );
                    }
                    else
                    {
                        Console.WriteLine(
                            "You search your bag a healing potion, and quickly pull out a green flask"
                        );

                        int potionValue = 5;
                        Console.WriteLine("You take a big zip. AHHH!");
                        Console.WriteLine($"You gain {health} health");
                        Program.currentPlayer.health += potionValue;
                        Console.WriteLine(
                            $"As you were drinking your potion, the {n} strikes you."
                        );
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine($"You lose {damage} health.");
                    }

                    Console.ReadKey();
                }

                //Death

                if (Program.currentPlayer.health <= 0)
                {
                    Console.WriteLine(
                        $"Suddenly {n} hits you with a fast and deadly blow. {n} stands victorious growling loud!"
                    );
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
            int coins = Program.currentPlayer.GetCoins();

            Console.WriteLine($"After killing {n}, you loot it's body for {coins} gold coins.");
            Console.WriteLine($"You put the {coins} coins in your purse.");
            Program.currentPlayer.coins += coins;
            Console.ReadKey();
        }
    }
}
