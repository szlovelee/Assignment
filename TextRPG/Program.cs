// 코드 공유
using System;
using System.Threading;

namespace TextRPG
{
    class TextRPG
    {
        private static void Main(string[] args)
        {
            GameSetting();
            Warrior warrior = new Warrior();
            Stage stage1 = new Stage(2, warrior);

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
                else
                {
                    InputBox();
                    GetInput();
                }

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
            Console.SetCursorPosition(10, 51);
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.SetCursorPosition(10, 52);
            Console.Write(">> ");
            Console.ResetColor();
        }
    }
}