using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq;
using Modnar_Classes;

namespace Modnar_Model
{
   public class DatabaseManager
    {
        public void CreateMonster(string name, int health, int damage, int speed)
        {
            using (var db = new ModnarContext())
            {
                db.Add(new Monster{ Name = name,Health = health, Damage = damage,Speed=speed });
                db.SaveChanges();
            }
        }
        public Monster ReadMonster(int id)
        {
            using (var db = new ModnarContext())
            {
                var monster = db.Monsters
                    .Where(m => m.monsterID == id)
                    .First();
                    return monster;
            }

            
        }

        public Monster RandomMonster()
        {
            Random rand = new Random();
           
            using (var db = new ModnarContext())
            {
                int id = rand.Next(1, db.Monsters.Count()+1);
                var monster = db.Monsters
                    .Where(m => m.monsterID == id)
                    .First();
                return monster;
            }
        }
    }
}
