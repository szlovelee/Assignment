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
        public static Warrior warrior;
        public static Monster monster;
        public HealthPotion healthPotion = new HealthPotion();
        public StrengthPotion strengthPotion = new StrengthPotion();
        public int StageLevel { get; set; }
        public static int SkillPoint { get; set; }
        public static int UltimateGage { get; set; }
        public static int TurnCount { get; set; }


        public Stage(int stageLevel, Warrior player)
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
            monster.DrawImage();
            warrior.DrawImage();
            DrawStatus();


            while (!warrior.IsDead && !monster.IsDead)
            {
                TextRPG.InputBox();
                Thread.Sleep(1000);
                MonsterAttack();

                Thread.Sleep(500);

                ShowOption();
                int input = TextRPG.CheckValidInput(0, 3);
                PlayerAttack(input);
            }

        }

        void Fight()
        {

        }

        static void MonsterAttack()
        {
            Console.SetCursorPosition(5, 10);
            Console.Write("▶▶▶");
            Console.SetCursorPosition(90, Console.CursorTop);
            Console.Write("        ");
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
                        //Console.WriteLine("전투 스킬 포인트가 부족합니다.");

                        break;
                    }
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
                        //Console.WriteLine("필살기 게이지가 충분하지 않습니다.");
                        break;
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
            Console.Write($"( {monster.Health} / {monster.MaxHealth} )");


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
            Console.Write($"( {warrior.Health} / {warrior.MaxHealth} )");


            // 필살기 게이지 & 전투 스킬 포인트
            Console.SetCursorPosition(105, 44);
            Console.Write("|    필살기 게이지");

            Console.SetCursorPosition(130, 44);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("          ");
            Console.SetCursorPosition(130, 44);
            Console.BackgroundColor = ConsoleColor.Cyan;
            string ultimate = new string(' ', UltimateGage);
            Console.Write(ultimate);
            Console.ResetColor();

            Console.SetCursorPosition(105, 43);
            Console.WriteLine("|");
            Console.SetCursorPosition(105, 45);
            Console.WriteLine("|");
            Console.SetCursorPosition(105, 46);
            Console.Write("|    전투 스킬 포인트");

            Console.SetCursorPosition(130, Console.CursorTop);
            int count = 1;
            for (int i = 0; i < 5; i++)
            {
                if (count <= SkillPoint) Console.Write("● ");
                else Console.Write("○ ");
                ++count;
            }

            // 박스 그리기
            Console.SetCursorPosition(5, 42);
            string line = new string('-', 140);
            Console.WriteLine(line);

            Console.SetCursorPosition(105, 43);
            Console.WriteLine("|");
            Console.SetCursorPosition(105, 45);
            Console.WriteLine("|");
            Console.SetCursorPosition(105, 47);
            Console.WriteLine("|");

            Console.SetCursorPosition(5, 48);
            Console.WriteLine(line);

            // HP 감소 표시 초기화

            Thread.Sleep(1000);
            Console.SetCursorPosition(35, 36);
            Console.WriteLine("           ");
            Console.SetCursorPosition(95, 36);
            Console.WriteLine("           ");
        }


        static void ShowOption()
        {
            Console.SetCursorPosition(5, 42);
            string line = new string('-', 140);
            Console.WriteLine(line);
            Console.SetCursorPosition(20, 44);
            Console.WriteLine("[1]                             [2]                             [3]");
            Console.SetCursorPosition(17, 46);
            Console.WriteLine("일반 공격                       전투 스킬                         필살기");

            TextRPG.GetInput();
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
