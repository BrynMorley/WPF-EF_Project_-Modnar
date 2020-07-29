using System;
using System.Collections.Generic;
using System.Text;

namespace Modnar_Classes
{
   public class Player : Character
    {
        int MaxHealth= 0;

        public Player (string name, int health, int damage, int speed) : base(name, health, damage, speed)
        {
            MaxHealth = health;
        }

        public Player()
        {
        
        }
        public int playerID { get; set; }

        public string Heal()
        {
            const int HealAmount = 50;
            Health += HealAmount;
            if (Health > MaxHealth) Health = MaxHealth;
            return $"{Name} heals {HealAmount} ";
        }
    }
}
