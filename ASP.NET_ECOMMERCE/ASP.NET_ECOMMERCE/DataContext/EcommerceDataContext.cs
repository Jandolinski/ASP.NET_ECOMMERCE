﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using ASP.NET_ECOMMERCE.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASP.NET_ECOMMERCE.DataContext
{
    public class EcommerceDataContext : DbContext
    {
        public EcommerceDataContext() : base("Ecommerce")
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Producer> Producers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(n => n.Id);
            modelBuilder.Entity<Producer>().HasKey(n => n.Id);
            modelBuilder.Entity<Product>().HasKey(n => new {n.CategoryId, n.ProducerId});

            modelBuilder.Entity<Product>()
                .HasRequired(q => q.Category)
                .WithMany(q => q.Products)
                .HasForeignKey(q => q.CategoryId);

            modelBuilder.Entity<Product>()
                .HasRequired(q => q.Producer)
                .WithMany(q => q.Products)
                .HasForeignKey(q => q.ProducerId);
        }

        public static EcommerceDataContext Create()
        {
            return new EcommerceDataContext();
        }
    }
}