using System;
using System.Collections.Generic;
using System.Text;

namespace Modnar_Classes
{
   public class Player : Character
    {
       private int _maxHealth;
        private int _healsLeft = 3;
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
            if (_healsLeft > 0)
            {
                const int HealAmount = 50;
                Health += HealAmount;
                if (Health > _maxHealth) Health = _maxHealth;
                _healsLeft--;
                return $"{Name} heals {HealAmount} ";
            }
            return $"{Name} is out of heals! Turn wasted!";

        }

        public string Taunt(IAttackable target)
        {
            return $"{Name} taunts the {target.Name}";
        }

        public override string ToString()
        {
            return $"Name: {Name}, Health: {Health}, Damage: {Damage}";
        }
    }
}
