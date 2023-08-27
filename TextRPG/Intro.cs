using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
    class Intro
    {
        public static ICharacter DisplayIntro()
        {
            // 타이틀 출력 
            Console.Clear();
            string title = "\r\n _________  _______      ___    ___ _________        ________  ________  ________     \r\n|\\___   ___\\\\  ___ \\    |\\  \\  /  /|\\___   ___\\     |\\   __  \\|\\   __  \\|\\   ____\\    \r\n\\|___ \\  \\_\\ \\   __/|   \\ \\  \\/  / ||___ \\  \\_|     \\ \\  \\|\\  \\ \\  \\|\\  \\ \\  \\___|    \r\n     \\ \\  \\ \\ \\  \\_|/__  \\ \\    / /     \\ \\  \\       \\ \\   _  _\\ \\   ____\\ \\  \\  ___  \r\n      \\ \\  \\ \\ \\  \\_|\\ \\  /     \\/       \\ \\  \\       \\ \\  \\\\  \\\\ \\  \\___|\\ \\  \\|\\  \\ \r\n       \\ \\__\\ \\ \\_______\\/  /\\   \\        \\ \\__\\       \\ \\__\\\\ _\\\\ \\__\\    \\ \\_______\\\r\n        \\|__|  \\|_______/__/ /\\ __\\        \\|__|        \\|__|\\|__|\\|__|     \\|_______|\r\n                        |__|/ \\|__|                                                   \r\n                                                                                      \r\n                                                                                      \r\n";
            string[] titleImage = title.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            Console.SetCursorPosition(30, 15);
            foreach (string t in titleImage)
            {
                Console.SetCursorPosition(30, Console.CursorTop);
                Console.WriteLine(t);
            }
            
            Console.ForegroundColor = ConsoleColor.Green;  
            Console.SetCursorPosition(68, 28);
            Console.WriteLine("<< START >>");
            Console.ResetColor();

            // 이름 입력받기
            Console.BackgroundColor = ConsoleColor.Magenta;
            string line = new string('=', 30);
            Console.SetCursorPosition(56, 33);
            Console.WriteLine($"▣{line}▣");

            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(56, Console.CursorTop);
                Console.WriteLine("||                              ||");
            }

            Console.SetCursorPosition(56, Console.CursorTop);
            Console.WriteLine($"▣{line}▣");

            
            ICharacter warrior = new Warrior();
            Console.ResetColor();

            //-------------------------------------------------

            return warrior;
        }


        public static void DisplayHome()
        {
            Console.Clear();

            // 타이틀
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("        _____ _____ _____ _____ \r\n       |  |  |     |     |   __|\r\n       |     |  |  | | | |   __|\r\n       |__|__|_____|_|_|_|_____|");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 12);
            string line = new string('=', 150);
            Console.WriteLine(line);
            Console.ResetColor();

            // 지시문
            Console.SetCursorPosition(10, 17);
            Console.WriteLine("스테이지를 선택하세요 >>>");

            // 아이템
            Console.ForegroundColor = ConsoleColor.Yellow;  
            line = new string('-', 40);
            Console.SetCursorPosition(101, 3);
            Console.WriteLine(line);

            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(100, Console.CursorTop);
                Console.WriteLine("|                                        |");
            }
            Console.SetCursorPosition(101, Console.CursorTop);
            Console.WriteLine(line);

            Console.SetCursorPosition(105, 5);
            Console.WriteLine("[아이템 목록]");
            Console.SetCursorPosition(105, 7);

            if (!TextRPG.strengthPotion && !TextRPG.healthPotion)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("소유한 아이템이 없습니다.");
                Console.ResetColor ();
            }
            else
            {
                if (TextRPG.healthPotion) Console.Write("체력 물약            ");
                if (TextRPG.strengthPotion) Console.Write("공격력 물약");
            }


            Console.ResetColor();

            // 몬스터 및 나의 정보
            ParticipantsInfo();


            // 입력 받기
            TextRPG.DrawOptionBox();
            ShowOption();

            TextRPG.InputBox();
            TextRPG.GetInput();
            int input = TextRPG.CheckValidInput(1, 4);

            if (input == 3)
            {
                if (TextRPG.healthPotion)
                {
                    TextRPG.warrior.MaxHealth += 5000;
                    TextRPG.warrior.Health = TextRPG.warrior.MaxHealth;
                    TextRPG.healthPotion = false;
                }
                else
                {
                    string message = "체력 물약이 없습니다.";
                    TextRPG.Warning(message);
                    Console.ResetColor();
                }
                DisplayHome();
                return;
            }
            else if (input == 4)
            {
                if (TextRPG.strengthPotion)
                {
                    TextRPG.warrior.Attack += 1000;
                    TextRPG.strengthPotion = false;
                }
                else
                {
                    string message = "공격력 물약이 없습니다.";
                    TextRPG.Warning(message);
                }
                DisplayHome();
                return;
            }

            Stage stage = new Stage(input, TextRPG.warrior);

            // 게임 후 데이터 리셋
            TextRPG.warrior.MaxHealth = 80000;
            TextRPG.warrior.Attack = 5000;
            TextRPG.warrior.Health = TextRPG.warrior.MaxHealth;
            TextRPG.warrior.IsDead = false;
            

            DisplayHome();
        }

        static void ShowOption()
        {
            TextRPG.DrawOptionBox();

            Console.SetCursorPosition(32, 44);
            Console.WriteLine("[1]");
            Console.SetCursorPosition(26, 46);
            Console.WriteLine("Stage 1 : 고블린");

            Console.SetCursorPosition(72, 44);
            Console.WriteLine("[2]");
            Console.SetCursorPosition(66, 46);
            Console.WriteLine("Stage 2 : 드래곤");

            Console.SetCursorPosition(120, 44);
            Console.WriteLine("* 물약 복용 *");
            Console.SetCursorPosition(110, 46);
            Console.WriteLine("[3] 체력 물략    [4] 공격력 물약");


        }

        static void ParticipantsInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            InfoBox(10);
            InfoBox(50);
            InfoBox(110);
            Console.ResetColor();

            MonsterInfo(1, "GOBLIN", 20000, 2000, 15);
            MonsterInfo(2, "DRAGON", 50000, 4000, 55);
            MyInfo();

        }

        static void InfoBox(int x)
        {
            Console.SetCursorPosition(x, 20);
            string line = new string('-', 30);
            Console.WriteLine(line);
            for (int i = 0; i < 15; i++)
            {
                Console.SetCursorPosition(x-1, Console.CursorTop);
                Console.WriteLine("|                              |");
            }
            Console.SetCursorPosition(x, Console.CursorTop);
            Console.WriteLine(line);
        }

        static void MonsterInfo(int num, string name, int hp, int power, int x)
        {
            Console.SetCursorPosition(x, 24);
            Console.WriteLine($"          {num}        ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;   
            Console.SetCursorPosition(x, Console.CursorTop);
            Console.WriteLine($"       {name}      ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.SetCursorPosition(x, Console.CursorTop);
            Console.WriteLine($"    HP :    {hp} ");
            Console.WriteLine() ;
            Console.SetCursorPosition(x, Console.CursorTop);
            Console.WriteLine($"    POWER : {power}   ");
        }

        static void MyInfo()
        {
            Console.SetCursorPosition(115, 24);
            Console.WriteLine($"       My Info.   ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(115, Console.CursorTop);
            Console.WriteLine($"        {TextRPG.warrior.Name}      ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.SetCursorPosition(115, Console.CursorTop);
            Console.WriteLine($"    HP :    {TextRPG.warrior.MaxHealth} ");
            Console.WriteLine();
            Console.SetCursorPosition(115, Console.CursorTop);
            Console.WriteLine($"    POWER : {TextRPG.warrior.Attack}   ");
        }
    }
}
