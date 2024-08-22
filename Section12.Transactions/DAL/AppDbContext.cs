using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section12.Transactions.DAL
{
    public class AppDbContext : DbContext
    {
        private DbConnection _connection;

        public AppDbContext(DbConnection connection)
        {
            _connection = connection;
        }
        public AppDbContext()
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connection is default(DbConnection))
            {
                Initializer.Build();
                optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
            }
            else
            {
                optionsBuilder.UseSqlServer(_connection);
            }    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(8,2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
