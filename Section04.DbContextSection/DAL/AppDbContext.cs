using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04.DbContextSection.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }


        //Tablo oluşurkenki özellikleri bu metod ile override ediyoruz
        //OnModelCreating Default özelliklerden uzaklaşmışsak DataAnnotationsa göre best practise
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().ToTable("ProductTBB","productstbb"); // Tablo ve şema adı değişimi
            modelBuilder.Entity<Product>().HasKey(p => p.Id); // Primary key belirleme

            base.OnModelCreating(modelBuilder);
        }

        /*
        public override int SaveChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(e =>
            {
                if (e.Entity is Product p) // Data Product ise
                {
                    if (e.State == EntityState.Added)
                    {
                        p.CreatedDate = DateTime.Now;
                    }
                }
            });

            return base.SaveChanges();
        }
        */

    }
}
