using System;
using System.Collections.Generic;
using System.Text;

namespace Modnar_Classes
{
   public abstract class Character
    {
        private int _health;
        private string _name;

        public int health
        {
            get { return _health; } set { _health = value; }
        }

        public string name
        {
            get { return _name; } set { _name = value; }
        }

        public Character (string name, int health)
        {
            _name = name;
            _health = health;
        }

    }
}