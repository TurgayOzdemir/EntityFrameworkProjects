﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Section10.StoreProceduredFunction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section10.StoreProceduredFunction.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductFull> ProductFulls { get; set; }
        //public DbSet<ProductWithFeature> ProductWithFeatures { get; set; }

        public DbSet<ProductCount> ProductCount { get; set; }

        public IQueryable<ProductWithFeature> GetProductWithFeatures(int categoryId){
            return FromExpression(() => GetProductWithFeatures(categoryId));
        } 

        public int GetProductCount(int categoryId)
        {
            throw new NotSupportedException("Bu metod EFCore tarafından çalıştırılmaktadır.");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(8,2);

            //modelBuilder.Entity<ProductFull>().HasNoKey();
            //modelBuilder.Entity<ProductFull>().Property(x => x.Price).HasPrecision(8,2);

            modelBuilder.Entity<ProductFull>().ToFunction("fc_product_full");
            modelBuilder.Entity<ProductWithFeature>().HasNoKey();

            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetProductWithFeatures), new[] { typeof(int) })!)
                .HasName("fc_product_full_with_param");

            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetProductCount), new[] { typeof(int) })!)
                .HasName("fc_get_product_count");

            modelBuilder.Entity<ProductCount>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
