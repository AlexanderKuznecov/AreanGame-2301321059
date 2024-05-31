using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;
using System;

namespace ConsoleArenaGame
{
    class Program
    {
        static int roundNumber = 0;

        static void ConsoleNotification(GameEngine.NotificationArgs args)
        {
            roundNumber++;
            Console.WriteLine($"---------- Round {roundNumber} ----------");
            Console.WriteLine($"{args.Attacker.Name} attacked {args.Defender.Name} with an attack power of {Math.Round(args.Attack, 2)}.");
            Console.WriteLine($"Damage caused: {Math.Round(args.Damage, 2)}");
            Console.WriteLine();
            Console.WriteLine("Attacker Status:");
            Console.WriteLine($"Name: {args.Attacker.Name}");
            Console.WriteLine($"Health: {Math.Round(args.Attacker.Health, 2)}");
            Console.WriteLine($"Weapon: {args.Attacker.Weapon.Name}");
            Console.WriteLine();
            Console.WriteLine("Defender Status:");
            Console.WriteLine($"Name: {args.Defender.Name}");
            Console.WriteLine($"Health: {Math.Round(args.Defender.Health, 2)}");
            Console.WriteLine($"Weapon: {args.Defender.Weapon.Name}");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }
        static Hero SelectHero(string heroName)
        {
            Console.WriteLine($"Select {heroName} hero:");
            Console.WriteLine("1. Knight (Health: 15, Armor: 10, Weapon: Sword)");
            Console.WriteLine("2. Assassin (Health: 10, Armor: 10, Weapon: Dagger)");
            Console.WriteLine("3. Vampire (Health: 10, Armor: 10, Weapon: Blood)");
            Console.WriteLine("4. Hunter (Health: 5, Armor: 10, Weapon: Bow)");
            Console.WriteLine("5. Tank (Health: 10, Armor: 10, Weapon: SpikedShield)");
            Console.WriteLine("6. Magician (Health: 7, Armor: 10, Weapon: Spells)");

            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    return new Knight("Knight", 15, 10, new Sword("Sword"));
                case 2:
                    return new Assassin("Assassin", 10, 10, new Dagger("Dagger"));
                case 3:
                    return new Vampire("Vampire", 10, 10, new Blood("Blood"));
                case 4:
                    return new Hunter("Hunter", 5, 10, new Bow("Bow"));
                case 5:
                    return new Tank("Tank", 10, 10, new SpikedShield("SpikedShield"));
                case 6:
                    return new Magician("Magician", 7, 10, new Spell("Spells"));
                default:
                    Console.WriteLine("Invalid choice, defaulting to Knight.");
                    return new Knight("Knight", 15, 10, new Sword("Sword"));
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Arena Game!");

            Hero heroA = SelectHero("Hero A");
            Hero heroB = SelectHero("Hero B");

            GameEngine gameEngine = new GameEngine()
            {
                HeroA = heroA,
                HeroB = heroB,
                NotificationsCallBack = ConsoleNotification
            };

            gameEngine.Fight();

            Console.WriteLine();
            Console.WriteLine($"The winner is {gameEngine.Winner.Name}!");
            Console.WriteLine($"Remaining Health: {Math.Round(gameEngine.Winner.Health, 2)}");
            Console.WriteLine($"Weapon Used: {gameEngine.Winner.Weapon.Name}");
        }
    }
}
