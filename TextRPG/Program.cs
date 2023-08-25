// 코드 공유
using System;
using System.Threading;

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
        Thread.Sleep(1000);
        Console.SetCursorPosition(95, 36);
        Console.WriteLine("           ");
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


class Monster : ICharacter
{
    protected string _name;
    protected int _health;
    protected int _maxHealth;
    protected int _attack;
    bool _idDead;
    protected string _image;

    public Monster(string name, int health, int attack, string image)
    {
        Name = name;
        Health = health;
        MaxHealth = health;
        Attack = attack;
        IsDead = false;
        Image = image;
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

        Console.SetCursorPosition(35, 36);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"-{damage}");
        Thread.Sleep(100);
        Console.SetCursorPosition(35, 36);
        Console.WriteLine($" -{damage}");
        Thread.Sleep(100);
        Console.SetCursorPosition(35, 36);
        Console.WriteLine($"  -{damage}");
        Thread.Sleep(1000);
        Console.SetCursorPosition(35, 36);
        Console.WriteLine("           ");
        Console.ResetColor();
    }

    public void DrawImage()
    {
        string[] MonImage = Image.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

        Console.SetCursorPosition(0, 12);
        foreach (string Mon in MonImage)
        {
            Console.SetCursorPosition(10, Console.CursorTop);
            
            Console.WriteLine($"{Mon}   ");
        }

    }

    public void ShakeImage()
    {
        string[] MonImage = Image.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

        Console.SetCursorPosition(0, 12);
        foreach (string Mon in MonImage)
        {
            Console.SetCursorPosition(12, Console.CursorTop);
            Console.WriteLine(Mon);
        }

    }
}

class Goblin : Monster
{
    static string image = "                                        \r\n     .:.                                \r\n    -=*##+=.            .-=+-           \r\n    .   -=+#=.        .*##**#+::..      \r\n           -##+.       +**###*-::.      \r\n             -+**+=-:.-**###-           \r\n                .-+##*#%%%%*            \r\n                    +-+*%@%%#:          \r\n                    :=+*#%####+         \r\n                    :=+*#######         \r\n                    .+*#%##+ #*:        \r\n                    :=+###+  -*=        \r\n                   .=+##%%:   #*.       \r\n                   =+##%%#+   -#=       \r\n                   *+**#*##:   *#       \r\n                  :*#+..+%%+   :*.      \r\n                  =#+    -##:  -*-      \r\n                 .**      -#* -**       \r\n                .*#:      :#%-+=        \r\n                -#+        #%-.         \r\n               :+#:        *++.         \r\n              :+**.       -*==+=        \r\n            .=+++-         :----+-:     \r\n           :=++=               .:-=.    \r\n             .                          \r\n";
    public Goblin() : base("Goblin", 20000, 2000, Goblin.image)
    {

    }
}

class Dragon : Monster
{
    static string image = "        `in)>,`                                   \r\n          1$$$$$#t{1c#,                ..'`;|`    \r\n         \"%$$$$$$$$$$$$&i..'         ^u$$$$%~.    \r\n      ,1&$$$$$$$$$$$$$$$$8}.     >rW$$$$$%;       \r\n         'i$$$$$$$$$$$$$$$#    `c$$$$$$t^         \r\n         `f$$$$$$$$$$$$$$$$,  l$$$$$$f'           \r\n        .```,_n$$$$$$$$$$$$n`f$$$$$8,        ].   \r\n               .;#$$$$$$$$$$$$$$$$M.     ..'';* .^\r\n                  j$$$$$$$$$$$$$$$*<:\"^,[W$$$$$rr,\r\n    `             I$$$$$$$$$$$$$$$$$$$$$$$$8$$$$$\"\r\n    l-.           \"$$$$$$$$$$$$$$$$$$$$$$v+n$$$$$l\r\n     IWW]^'.      .&$$$$$$$$$$$$$$$$$$$%-  [$$$$t \r\n       .'!W;.    `:*$$$$$$$$$$$$$$$$$/`    .$$$;  \r\n          ?W.  .:n$$$$$$$$$$$$$$$$$$>     .:B$B.  \r\n          }B  ^~8$$$$$$$$$$$$$$$$$$$B{`    '.:'   \r\n        .i$] +x$$$$$$$$$$$$$$$$W,.`,)#Wv}^        \r\n  '`,>|M$Bn)@$$$$$$$$$$$n-$$f@$@'    `'.-$z]I     \r\n<@$$$$$$$$$$$$$$$$$$$$8. /$B'I%$x        ;[^`     \r\n?@$$$$$$$$$$$$$$$z?\"]$@\" `}M@\\t%$)                \r\n  ^;+{\\/\\\\|{->:`.   `|$$+`. `/rn@$:..             \r\n";
    public Dragon() : base("Dragon", 50000, 4000, image)
    {
    }
}

interface IItem
{
    string Name { get; }
    void Use(Warrior warrior);
}

class HealthPotion : IItem
{
    string _name = "Health Potion";

    public string Name
    {
        get { return _name; }
    }

    public void Use(Warrior warrior)
    {
        warrior.Health += 2000;
    }

}

class StrengthPotion : IItem
{
    string _name = "Strength Potion";

    public string Name
    {
        get { return _name; }
    }

    public void Use(Warrior warrior)
    {
        warrior.Attack += 1000;     // 3턴 지속되게 하는 법?
    }
}

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
        DrawStatus();

        if (warrior.Health <= 0) warrior.IsDead = true;

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

        Console.SetCursorPosition(90, 38);
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.WriteLine("                              ");
        Console.SetCursorPosition(90, 38);
        Console.BackgroundColor = ConsoleColor.Green;
        string plHealth = new string(' ', (int)((warrior.Health * 30 / warrior.MaxHealth )));
        if (plHealth.Length <= 6) Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(plHealth);
        Console.ResetColor();

        Console.SetCursorPosition(125, 38);
        Console.Write($"( {warrior.Health} / {warrior.MaxHealth} )");

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
        Console.SetCursorPosition(4,Console.CursorTop);
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