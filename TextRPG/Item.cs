using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
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
}
