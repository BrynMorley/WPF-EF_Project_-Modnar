using System;
using System.Collections.Generic;
using System.Text;

namespace Modnar_Classes
{
   public class Player : Character
    {

        public Player (string name, int health, int damage, int speed) : base(name, health, damage, speed)
        {

        }

        public Player()
        { }
        public int playerID { get; set; }
    }
}
