// 코드 공유
using System;
using System.Threading;

interface ICharacter
{
    string Name { get; }
    int Health { get; set; }
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
    }

    public void DrawImage()
    {
        string[] WarImage = Image.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        Console.SetCursorPosition(90, 2);
        foreach (string War in WarImage) 
        {
            Console.SetCursorPosition(90, Console.CursorTop); 
            Console.WriteLine(War);
        }
        
    }

    public void ShakeImage()
    {
        string[] WarImage = Image.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        Console.SetCursorPosition(92, 2);
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
    protected int _attack;
    bool _idDead;
    protected string _image;

    public Monster(string name, int health, int attack, string image)
    {
        Name = name;
        Health = health;
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
    }

    public void DrawImage()
    {
        string[] MonImage = Image.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

        Console.SetCursorPosition(0, 1);
        Console.WriteLine("\n\n\n\n\n\n\n");
        foreach (string Mon in MonImage)
        {
            Console.SetCursorPosition(10, Console.CursorTop);
            Console.WriteLine(Mon);
        }

    }

    public void ShakeImage()
    {
        string[] MonImage = Image.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

        Console.SetCursorPosition(0, 1);
        Console.WriteLine("\n\n\n\n\n\n\n");
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
        Start();
        StageLevel = stageLevel;
        if (StageLevel == 1) monster = new Goblin();
        else monster = new Dragon();
        SkillPoint = 3;
        UltimateGage = 0;
        TurnCount = 0;
        warrior = player;
    }

    void Start()
    {

        while (!warrior.IsDead && !monster.IsDead)
        {
            MonsterAttack();

            int input = TextRPG.CheckValidInput(1, 3);
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

        warrior.TakeDagame(AttackDamage);
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
                Console.WriteLine("일반 공격!");
                ++SkillPoint;
                ++UltimateGage;
                MaxMinManager();
                break;
            case 2:
                if (SkillPoint != 0)
                {
                    prob = random.Next(30, 41);
                    AttackDamage = (int)(warrior.Attack * prob / 100);
                    Console.WriteLine("전투 스킬 발동!");
                    --SkillPoint;
                    UltimateGage += 3;
                    MaxMinManager();
                    break;
                }
                else
                {
                    Console.WriteLine("전투 스킬 포인트가 부족합니다.");

                    break;
                }
            case 3:
                if (UltimateGage == 10)
                {
                    prob = random.Next(90, 120);
                    AttackDamage = (int)(warrior.Attack * prob / 100);
                    Console.WriteLine("필살기");
                    UltimateGage = 0;
                    break;
                }
                else
                {
                    Console.WriteLine("필살기 게이지가 충분하지 않습니다.");
                    break;
                }
        }

        monster.TakeDagame(AttackDamage);
        if (monster.Health <= 0) monster.IsDead = true;
        
    }

    static void MaxMinManager()
    {
        if (SkillPoint <= 0) SkillPoint = 0;
        else if (SkillPoint >= 5) SkillPoint = 5;

        if (UltimateGage >= 10) UltimateGage = 10;
    }

    //static void ShowOption()
    //{
    //    Console.SetCursorPosition()
    //}
}

class TextRPG
{
    private static void Main(string[] args)
    {
        GameSetting();
        Monster  monster = new Dragon();
        Warrior warrior = new Warrior();
        monster.DrawImage();
        warrior.DrawImage();

        DrawHit(monster);
        Thread.Sleep(1000);

        DrawHit(warrior);

        Console.ReadLine()
;        

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

}


