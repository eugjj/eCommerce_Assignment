using System;
using Microsoft.EntityFrameworkCore;

namespace eCommence_Assignment.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder model)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<ProdctCategory> Categories { get; set; }
        public DbSet<Products> Products { get; set; }

        public DbSet<ProductKey> ProductKeys { get; set; }
    }
}
