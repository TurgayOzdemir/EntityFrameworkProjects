using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section08.ModelSection.DAL
{
    public class AppDbContext : DbContext
    {
        //public DbSet<Manager> Managers { get; set; }
        //public DbSet<Employee> Employees { get; set; }

        public DbSet<ProductFull> ProductFulls { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                        .HasOne(x => x.ProductFeature)
                        .WithOne(x => x.Product)
                        .HasForeignKey<ProductFeature>(x => x.Id);

            modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(8,2);

            modelBuilder.Entity<ProductFull>().HasNoKey();

            //----------------------------------------------------------------


            /*
            modelBuilder.Entity<Employee>().Property(x => x.Salary).HasPrecision(8,2);

            //Owned Type'da miras almak yerine Employee ve Manager İçinde Person person tanımladık.
            modelBuilder.Entity<Manager>().OwnsOne(x => x.Person, p =>
            {
                p.Property(x => x.FirstName).HasColumnName("FirstName");
                p.Property(x => x.LastName).HasColumnName("LastName");
                p.Property(x => x.Age).HasColumnName("Age");
            });
            modelBuilder.Entity<Employee>().OwnsOne(x => x.Person, p =>
            {
                p.Property(x => x.FirstName).HasColumnName("FirstName");
                p.Property(x => x.LastName).HasColumnName("LastName");
                p.Property(x => x.Age).HasColumnName("Age");
            });
            */

            base.OnModelCreating(modelBuilder);
        }

    }
}
