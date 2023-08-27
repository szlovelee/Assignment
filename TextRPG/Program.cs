// 코드 공유
using System;
using System.Threading;

namespace TextRPG
{
    class TextRPG
    {
        public static ICharacter warrior;
        public static bool healthPotion = false;
        public static bool strengthPotion = false;

        private static void Main(string[] args)
        {
            GameSetting();
            warrior = Intro.DisplayIntro();
            Intro.DisplayHome();

        }

        static void GameSetting()
        {
            Console.SetWindowSize(150, 60);
        }

        public static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();
                Console.ResetColor();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.SetCursorPosition(10, 51);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                string message = "잘못된 입력입니다.";

                Warning(message);
                  
                GetInput();
            }
        }

        static void DrawHit(ICharacter character)
        {
            Thread.Sleep(50);
            character.ShakeImage();
            Thread.Sleep(50);
            character.DrawImage();
            Thread.Sleep(50);
            character.ShakeImage();
            Thread.Sleep(50);
            character.DrawImage();
        }


        public static void InputBox()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            string line = new string('-', 140);
            string empty = new string(' ', 138);
            Console.SetCursorPosition(4, 50);
            Console.WriteLine($" {line} ");
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(4, Console.CursorTop);
                Console.Write(" |");
                Console.Write(empty);
                Console.WriteLine("| ");
            }
            Console.SetCursorPosition(4, Console.CursorTop);
            Console.WriteLine($" {line} ");
            Console.ResetColor();
        }


        public static void GetInput()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(10, 51);
            Console.WriteLine("원하시는 행동을 입력해주세요.     ");
            Console.SetCursorPosition(10, 52);
            Console.Write(">>            ");
            Console.SetCursorPosition(13, 52);

            Console.ResetColor();
        }

        public static void Warning(string message)
        {
            Console.SetCursorPosition(10, 51);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write($"{message}                 ");
            Console.SetCursorPosition(10, 52);
            Console.Write("         ");
            Console.SetCursorPosition(10, 52);
            Thread.Sleep(2000);
            Console.ResetColor();
        }

        public static void DrawOptionBox()
        {
            Console.SetCursorPosition(5, 42);
            string line = new string('-', 140);
            Console.WriteLine(line);

            Console.SetCursorPosition(105, 43);
            for (int i = 0; i< 5; i++)
            {
                Console.SetCursorPosition(105, Console.CursorTop);
                Console.WriteLine("|");
            }

            Console.SetCursorPosition(5, 48);
            Console.WriteLine(line);
        }
    }
}