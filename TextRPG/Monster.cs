using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRPG
{
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

}
