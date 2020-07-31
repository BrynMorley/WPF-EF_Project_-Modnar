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

        public Monster ReadFirstMonster()
        {
            using (var db = new ModnarContext())
            {
                var monster = db.Monsters
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

        public void CreatePlayer(string name, int health, int damage, int speed)
        {
            using (var db = new ModnarContext())
            {
                db.Add(new Player { Name = name, Health = health, Damage = damage, Speed = speed, MaxHealth = health }) ;
                db.SaveChanges();
            }
        }

        public Player ReadPlayerID(int id)
        {
            using (var db = new ModnarContext())
            {
                var player = db.Players
                    .Where(p => p.playerID == id)
                        .First();
                    return player;
            }
        }

        public List<Player> ReadPlayer_List()
        {
            using (var db = new ModnarContext())
            {
                return db.Players
                    .ToList();
            }  
        }

    }


}
