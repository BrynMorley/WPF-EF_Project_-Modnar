using System;
using System.Collections.Generic;
using System.Text;

namespace Modnar_Classes
{
   public abstract class Character : IAttackable
    {
        private int _health;
        private string _name;
        private int _damage;
        private int _speed;

       
        public int Health
        {
            get { return _health; } set { _health = value; }
        }

        public string Name
        {
            get { return _name; } set { _name = value; }
        }

        public int Damage
        {
            get { return _damage; } set { _damage = value; }
        }

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Character (string name, int health, int damage, int speed)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _speed = speed;
        }

        public virtual string Attack(IAttackable target)
        {
            target.Health -= _damage;
            if (target.Health > 0)
            {
                return $"{_name} attacks {target.Name} dealing {_damage} damage";
            }
            else
            {
                return $"{_name} attacks {target.Name} and kills it!!!";
            }
            
        }
    }
}