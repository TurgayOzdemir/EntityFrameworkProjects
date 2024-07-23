using Microsoft.EntityFrameworkCore;
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
        public DbSet<ProductWithFeature> ProductWithFeatures { get; set; }

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
