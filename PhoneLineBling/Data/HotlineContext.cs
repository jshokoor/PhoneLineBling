using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneLineBling.Models;
using Microsoft.EntityFrameworkCore;

namespace PhoneLineBling.Data
{
    public class HotlineContext : DbContext
    {
        public HotlineContext(DbContextOptions<HotlineContext> options) 
            : base(options)
        {
        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Fetish> Fetishes { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>().ToTable("Subscription");
            modelBuilder.Entity<Fetish>().ToTable("Fetish");
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }
    }

    
}
