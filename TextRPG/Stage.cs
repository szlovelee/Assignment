using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRPG
{
    class Stage
    {
        public static ICharacter warrior;
        public static ICharacter monster;

        public int StageLevel { get; set; }
        public static int SkillPoint { get; set; }
        public static int UltimateGage { get; set; }
        public static int TurnCount { get; set; }


        public Stage(int stageLevel, ICharacter player)
        {
            StageLevel = stageLevel;
            if (StageLevel == 1) monster = new Goblin();
            else monster = new Dragon();
            SkillPoint = 3;
            UltimateGage = 0;
            TurnCount = 0;
            warrior = player;
            Start();
        }

        void Start()
        {
            Console.Clear();


            // 타이틀 그리기

            string line = new string('-', 48);
            Console.SetCursorPosition(6, 2);
            Console.WriteLine(line);

            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(5, Console.CursorTop);
                Console.WriteLine("|                                                |");
            }
            Console.SetCursorPosition(6, Console.CursorTop);
            Console.WriteLine(line);

            string title;

            if (this.StageLevel == 1) title = " _____ _____ _____ _____ _____    ___   \r\n|   __|_   _|  _  |   __|   __|  |_  |  \r\n|__   | | | |     |  |  |   __|   _| |_ \r\n|_____| |_| |__|__|_____|_____|  |_____|";
            else title = " _____ _____ _____ _____ _____    ___ \r\n|   __|_   _|  _  |   __|   __|  |_  |\r\n|__   | | | |     |  |  |   __|  |  _|\r\n|_____| |_| |__|__|_____|_____|  |___|";
            string[] titleImage = title.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            Console.SetCursorPosition(10, 3);
            foreach (string t in titleImage)
            {
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.WriteLine(t);
            }

            // ------------------------------------------------

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(133, 56);
            Console.WriteLine("[0] 나가기");
            Console.ResetColor();

            monster.DrawImage();
            warrior.DrawImage();
            DrawStatus();




            while (!warrior.IsDead && !monster.IsDead)
            {

                Thread.Sleep(1000);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(5, 10);
                Console.Write("▶▶▶");
                Console.SetCursorPosition(80, Console.CursorTop);
                Console.Write("        ");
                Thread.Sleep(500);
                Console.ResetColor();

                MonsterAttack();
                Thread.Sleep(500);

                if (warrior.IsDead || monster.IsDead) break;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(5, 10);
                Console.Write("        ");
                Console.SetCursorPosition(80, Console.CursorTop);
                Console.Write("▶▶▶");
                Console.ResetColor();

                ShowOption();
                TextRPG.GetInput();
                int input = TextRPG.CheckValidInput(0, 3);

                if (input == 0)
                {
                    Intro.DisplayHome();
                    return;
                }

                PlayerAttack(input);
            }

            DisplayResult();

        }

        static void MonsterAttack()
        {
            Random random = new Random();
            int prob;
            int AttackDamage = 0;

            if (TurnCount == 5)
            {
                prob = random.Next(10, 51);
                AttackDamage = (monster.Attack * prob / 100);
                TurnCount = 0;
            }
            else
            {
                prob = random.Next(70, 110);
                AttackDamage = (monster.Attack * prob / 100);
            }

            DrawHit(warrior);
            warrior.TakeDagame(AttackDamage);

            if (warrior.Health <= 0)
            {
                warrior.IsDead = true;
                return;
            }

            ++UltimateGage;
            MaxMinManager();
            DrawStatus();


            ++TurnCount;

        }

        static void DisplayResult()
        {
            Console.Clear();

            string title;

            if (warrior.IsDead)
            {
                title = "\r\n$$\\     $$\\  $$$$$$\\  $$\\   $$\\       $$\\       $$$$$$\\   $$$$$$\\  $$$$$$$$\\ \r\n\\$$\\   $$  |$$  __$$\\ $$ |  $$ |      $$ |     $$  __$$\\ $$  __$$\\ $$  _____|\r\n \\$$\\ $$  / $$ /  $$ |$$ |  $$ |      $$ |     $$ /  $$ |$$ /  \\__|$$ |      \r\n  \\$$$$  /  $$ |  $$ |$$ |  $$ |      $$ |     $$ |  $$ |\\$$$$$$\\  $$$$$\\    \r\n   \\$$  /   $$ |  $$ |$$ |  $$ |      $$ |     $$ |  $$ | \\____$$\\ $$  __|   \r\n    $$ |    $$ |  $$ |$$ |  $$ |      $$ |     $$ |  $$ |$$\\   $$ |$$ |      \r\n    $$ |     $$$$$$  |\\$$$$$$  |      $$$$$$$$\\ $$$$$$  |\\$$$$$$  |$$$$$$$$\\ \r\n    \\__|     \\______/  \\______/       \\________|\\______/  \\______/ \\________|\r\n                                                                             \r\n                                                                             \r\n                                                                             \r\n";
            }
            else
            {
                title = "\r\n$$\\     $$\\  $$$$$$\\  $$\\   $$\\       $$\\      $$\\ $$$$$$\\ $$\\   $$\\       $$\\ \r\n\\$$\\   $$  |$$  __$$\\ $$ |  $$ |      $$ | $\\  $$ |\\_$$  _|$$$\\  $$ |      $$ |\r\n \\$$\\ $$  / $$ /  $$ |$$ |  $$ |      $$ |$$$\\ $$ |  $$ |  $$$$\\ $$ |      $$ |\r\n  \\$$$$  /  $$ |  $$ |$$ |  $$ |      $$ $$ $$\\$$ |  $$ |  $$ $$\\$$ |      $$ |\r\n   \\$$  /   $$ |  $$ |$$ |  $$ |      $$$$  _$$$$ |  $$ |  $$ \\$$$$ |      \\__|\r\n    $$ |    $$ |  $$ |$$ |  $$ |      $$$  / \\$$$ |  $$ |  $$ |\\$$$ |          \r\n    $$ |     $$$$$$  |\\$$$$$$  |      $$  /   \\$$ |$$$$$$\\ $$ | \\$$ |      $$\\ \r\n    \\__|     \\______/  \\______/       \\__/     \\__|\\______|\\__|  \\__|      \\__|\r\n                                                                               \r\n                                                                               \r\n                                                                               \r\n";

                // 승리 보상 - 포션 지급

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(63, 33);
                if (!TextRPG.healthPotion)
                {
                    Console.WriteLine("+ 체력 포션 획득");
                    Console.WriteLine();
                }

                Console.SetCursorPosition(63, Console.CursorTop);
                if (!TextRPG.strengthPotion) Console.WriteLine("+ 공격력 포션 획득");
                Console.ResetColor();

                TextRPG.healthPotion = true;
                TextRPG.strengthPotion = true;
            }


            string[] titleImage = title.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            Console.SetCursorPosition(35, 18);
            foreach (string t in titleImage)
            {
                Console.SetCursorPosition(35, Console.CursorTop);
                Console.WriteLine(t);
            }

            Thread.Sleep(5000);
        }

        static void PlayerAttack(int input)
        {
            Random random = new Random();
            int prob;
            int AttackDamage = 0;
            switch (input)
            {
                case 1:
                    prob = random.Next(20, 31);
                    AttackDamage = (int)(warrior.Attack * prob / 100);
                    //Console.WriteLine("일반 공격!");
                    ++SkillPoint;
                    ++UltimateGage;
                    MaxMinManager();
                    break;

                case 2:
                    if (SkillPoint != 0)
                    {
                        prob = random.Next(30, 41);
                        AttackDamage = (int)(warrior.Attack * prob / 100);
                        //Console.WriteLine("전투 스킬 발동!");
                        --SkillPoint;
                        UltimateGage += 3;
                        MaxMinManager();
                        break;
                    }
                    else
                    {
                        string message1 = "잘못된 입력입니다.";
                        string message2 = "전투 스킬 포인트가 부족합니다.";

                        TextRPG.Warning(message2);

                        TextRPG.GetInput();

                        while (true)
                        {
                            string newInput = Console.ReadLine();
                            Console.ResetColor();
                            bool parseSuccess = int.TryParse(newInput, out var ret);
                            if (parseSuccess)
                            {
                                if (ret >= 0 && ret <= 3 && ret != 2)
                                {
                                    PlayerAttack(ret);
                                    return;
                                }

                            }

                            if (ret == 2) TextRPG.Warning(message2);
                            else TextRPG.Warning(message1);

                            TextRPG.GetInput();
                        }
                    }
                    break;

                case 3:
                    if (UltimateGage == 10)
                    {
                        prob = random.Next(90, 120);
                        AttackDamage = (int)(warrior.Attack * prob / 100);
                        //Console.WriteLine("필살기");
                        UltimateGage = 0;
                        break;
                    }
                    else
                    {
                        string message1 = "잘못된 입력입니다.";
                        string message2 = "필살기 게이지가 충분하지 않습니다.";

                        TextRPG.Warning(message2);

                        TextRPG.GetInput();

                        while (true)
                        {
                            string newInput = Console.ReadLine();
                            Console.ResetColor();
                            bool parseSuccess = int.TryParse(newInput, out var ret);
                            if (parseSuccess)
                            {
                                if (ret >= 0 && ret <= 2)
                                {
                                    PlayerAttack(ret);
                                    return;
                                }

                            }

                            if (ret == 3) TextRPG.Warning(message2);
                            else TextRPG.Warning(message1);

                            TextRPG.GetInput();
                        }
                    }
            }
            DrawHit(monster);
            monster.TakeDagame(AttackDamage);
            DrawStatus();

            if (monster.Health <= 0) monster.IsDead = true;

        }

        static void MaxMinManager()
        {
            if (SkillPoint <= 0) SkillPoint = 0;
            else if (SkillPoint >= 5) SkillPoint = 5;

            if (UltimateGage >= 10) UltimateGage = 10;
        }



        static void DrawStatus()
        {
            TextRPG.InputBox();
            ShowOption();

            // 몬스터 HP 
            Console.SetCursorPosition(10, 38);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("                              ");
            Console.SetCursorPosition(10, 38);
            Console.BackgroundColor = ConsoleColor.Green;
            string monHealth = new string(' ', (int)((monster.Health * 30 / monster.MaxHealth)));
            if (monHealth.Length <= 6) Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(monHealth);
            Console.ResetColor();

            Console.SetCursorPosition(45, 38);
            Console.Write($"( {monster.Health} / {monster.MaxHealth} )        ");


            // 플레이어 HP
            Console.SetCursorPosition(90, 38);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("                              ");
            Console.SetCursorPosition(90, 38);
            Console.BackgroundColor = ConsoleColor.Green;
            string plHealth = new string(' ', (int)((warrior.Health * 30 / warrior.MaxHealth)));
            if (plHealth.Length <= 6) Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(plHealth);
            Console.ResetColor();

            Console.SetCursorPosition(125, 38);
            Console.Write($"( {warrior.Health} / {warrior.MaxHealth} )        ");


            // 필살기 게이지 & 전투 스킬 포인트
            Console.SetCursorPosition(110, 44);
            Console.Write("필살기 게이지");

            Console.SetCursorPosition(130, 44);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("          ");
            Console.SetCursorPosition(130, 44);
            Console.BackgroundColor = ConsoleColor.Cyan;
            string ultimate = new string(' ', UltimateGage);
            Console.Write(ultimate);
            Console.ResetColor();

            Console.SetCursorPosition(110, 46);
            Console.Write("전투 스킬 포인트");

            Console.SetCursorPosition(130, Console.CursorTop);
            int count = 1;
            for (int i = 0; i < 5; i++)
            {
                if (count <= SkillPoint) Console.Write("● ");
                else Console.Write("○ ");
                ++count;
            }

            // HP 감소 표시 초기화

            Thread.Sleep(1000);
            Console.SetCursorPosition(35, 36);
            Console.WriteLine("           ");
            Console.SetCursorPosition(95, 36);
            Console.WriteLine("           ");

            TextRPG.InputBox();
        }


        static void ShowOption()
        {
            TextRPG.DrawOptionBox();

            Console.SetCursorPosition(20, 44);
            Console.WriteLine("[1]");
            Console.SetCursorPosition(17, 46);
            Console.WriteLine("일반 공격");

            if (SkillPoint == 0) Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.SetCursorPosition(52, 44);
            Console.WriteLine("[2]");
            Console.SetCursorPosition(49, 46);
            Console.WriteLine("전투 스킬");

            Console.ResetColor();

            if (UltimateGage != 10) Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.SetCursorPosition(84, 44);
            Console.WriteLine("[3]");
            Console.SetCursorPosition(83, 46);
            Console.WriteLine("필살기");

            Console.ResetColor();

            Console.SetCursorPosition(13, 52);
        }

        static void DrawHit(ICharacter character)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Thread.Sleep(50);
            character.ShakeImage();
            Thread.Sleep(50);
            character.DrawImage();
            Thread.Sleep(50);
            character.ShakeImage();
            Thread.Sleep(50);
            Console.ResetColor();
            character.DrawImage();
        }
    }

}
