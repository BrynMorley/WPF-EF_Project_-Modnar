using System;

namespace Modnar_Classes
{
    public class Monster : Character
    {
        public Monster(string name, int health, int damage,int speed) : base(name, health, damage, speed)
        {

        }

        public Monster()
        { }

        public int monsterID { get; set; }
    }
}
