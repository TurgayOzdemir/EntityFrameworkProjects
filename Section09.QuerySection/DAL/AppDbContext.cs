﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Section09.QuerySection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section09.QuerySection.DAL
{
    public class AppDbContext : DbContext
    {
        private readonly int Barcode;

        public AppDbContext(int barcode)
        {
            Barcode = barcode;
        }

        public AppDbContext()
        {
            
        }


        //public DbSet<Person> People { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<Category> Categories { get; set; }


        //public DbSet<ProductEssential> ProductEssentials { get; set; }
        //public DbSet<ProductWithFeature> ProductWithFeatures { get; set; }
        //public DbSet<ProductFull> ProductFulls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                          .UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"))
                          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);// HER ZAMAN NOTRACKİNG İŞARETLER
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(8,2);
            modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);
            modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);

            //modelBuilder.Entity<ProductEssential>().HasNoKey().ToSqlQuery("Select Name, Price From Products");

            //modelBuilder.Entity<ProductWithFeature>().HasNoKey().Property(x => x.Price).HasPrecision(8, 2);

            //modelBuilder.Entity<ProductFull>().ToView("vw_productWithFeature");

            /*modelBuilder.Entity<Product>().Property(x => x.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted); //HER SORGUYA OTOMATİK OLARAK EKLENECEK

            if (Barcode != default(int))
            {
                modelBuilder.Entity<Product>().HasQueryFilter(p => p.Barcode == Barcode);
            }*/



            base.OnModelCreating(modelBuilder);
        }

    }
}
