using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Modnar_Classes;


namespace Modnar_Model
{
    public class ModnarContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Monster> Monsters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
              => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Modnar;");

    }

    /*
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }

    }

    public class Monster
    {
        public int MonsterId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }

    }
    */
}