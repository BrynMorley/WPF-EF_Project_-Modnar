using System;
using System.Collections.Generic;
using System.Text;

namespace Modnar_Classes
{
   public class Player : Character
    {
       private int _maxHealth;

        public Player (string name, int health, int damage, int speed, int maxHealth) : base(name, health, damage, speed)
        {
           _maxHealth = maxHealth;
        }

        public Player()
        {
        
        }
        public int playerID { get; set; }

        public int MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

        public string Heal()
        {
            const int HealAmount = 50;
            Health += HealAmount;
            if (Health > _maxHealth) Health = _maxHealth;
            return $"{Name} heals {HealAmount} ";
        }

        public string Taunt(IAttackable target)
        {
            return $"{Name} taunts the {target.Name}";
        }
    }
}
