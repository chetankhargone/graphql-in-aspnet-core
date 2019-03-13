using Microsoft.EntityFrameworkCore;
using OrdersLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersLib.Db
{
    public class OrdersContext : DbContext
    {
        private const string _dbConnection = "Data Source = 10.10.10.125; Initial Catalog = graphql-dev;Persist Security Info=True;User ID = sa;Password=Pass2018;Encrypt=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbConnection);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
