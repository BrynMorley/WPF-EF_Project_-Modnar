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

   
}