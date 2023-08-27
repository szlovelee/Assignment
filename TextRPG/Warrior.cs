using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRPG
{
    interface ICharacter
    {
        string Name { get; }
        int Health { get; set; }
        int MaxHealth { get; set; }
        int Attack { get; set; }
        bool IsDead { get; set; }

        string Image { get; set; }

        void TakeDagame(int damage);

        void DrawImage();

        void ShakeImage();
    }

    class Warrior : ICharacter
    {
        string _name;
        int _health;
        int _attack;
        bool _idDead;
        string _image = "               -                        \r\n             .-.                        \r\n           :-.                          \r\n         --                             \r\n       .=.                              \r\n      =+               =+*+:    :+=+-   \r\n     *@.             .%@@@@@+   *%##=   \r\n   .**:              .@@@@@@# .==-.     \r\n    %:                +@@@@%-=#=.       \r\n ..:%#..::-=+:     .::-#@@@*@@@*#%@*.   \r\n   .@@%@@@@@@@@@@@@@@@@@@@@@@@@@@@%*:   \r\n   .@=    ....      .#@@@@@@@@*:        \r\n   :@:               @@@@@@@@@          \r\n    =@%              .@@@@@@@+          \r\n     =@               *@@@@@@.          \r\n      :*              %@@@@@@*          \r\n        =:           *@@@@@@@@=         \r\n         :-.         @@@@@@@@@@.        \r\n           .-.      :@@@@%#@@@@%        \r\n             .:     -@@@@* %@@@@*       \r\n              :     :@@@@= .%@@@@       \r\n                     %@@@.   #@@@:      \r\n                     -@@@     %@@-      \r\n                      @@@     -@@#:     \r\n                     *@@@      @@@@+    \r\n                     @@@@:     =@@@@.   \r\n                     @@@@:      +@@@+   \r\n                     +@@%        +@@%   \r\n                     -@@+         -@@=  \r\n                      @@:          #@@. \r\n                     .@@           .=%%=\r\n";

        public Warrior()
        {
            Console.SetCursorPosition(60, 35);
            Console.Write("Enter Your Name: ");
            string input = Console.ReadLine();

            Name = input;
            Health = 80000;
            MaxHealth = 80000;
            Attack = 5000;
            IsDead = false;

        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int MaxHealth { get; set; }

        public int Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }
        public bool IsDead
        {
            get { return _idDead; }
            set { _idDead = value; }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public void TakeDagame(int damage)
        {
            if (Health > damage)
            {
                Health -= damage;
            }
            else
            {
                Health = 0;
            }

            Console.SetCursorPosition(95, 36);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"-{damage}");
            Thread.Sleep(100);
            Console.SetCursorPosition(95, 36);
            Console.WriteLine($" -{damage}");
            Thread.Sleep(100);
            Console.SetCursorPosition(95, 36);
            Console.WriteLine($"  -{damage}");
            Console.ResetColor();
        }

        public void DrawImage()
        {
            string[] WarImage = Image.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Console.SetCursorPosition(90, 5);
            foreach (string War in WarImage)
            {
                Console.SetCursorPosition(90, Console.CursorTop);
                Console.WriteLine($"{War}   ");
            }

        }

        public void ShakeImage()
        {
            string[] WarImage = Image.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Console.SetCursorPosition(92, 5);
            foreach (string War in WarImage)
            {
                Console.SetCursorPosition(92, Console.CursorTop);
                Console.WriteLine(War);
            }

        }
    }
}
