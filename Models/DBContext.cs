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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
