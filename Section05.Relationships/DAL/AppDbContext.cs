using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section05.Relationships.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<ProductFeature> ProductFeature { get; set; }

        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().Property(x => x.PriceKdv).HasComputedColumnSql("[Price]*[Kdv]");

            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedOnAdd(); //İdentity
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedOnAddOrUpdate(); //Computed
            //modelBuilder.Entity<Product>().Property(x => x.PriceKdv).ValueGeneratedNever(); //None

            //------------------------------------------------


            /*
            //Cascade dafault davranışıdır. Ürüne ait kategori silindiğinde o kategorideki tüm ürünler silinir.
            modelBuilder.Entity<Category>().HasMany(x => x.Products)
                                           .WithOne(x => x.Category)
                                           .HasForeignKey(x => x.CategoryId)
                                           .OnDelete(DeleteBehavior.Cascade);
            */
            /*
            //Restrict ürüne ait kategori silinmek istendiğinde o kategoriye sahip ürün varsa engeller.
            modelBuilder.Entity<Category>().HasMany(x => x.Products)
                                           .WithOne(x => x.Category)
                                           .HasForeignKey(x => x.CategoryId)
                                           .OnDelete(DeleteBehavior.Restrict);
            */

            /*
            //NoAction -> Kategori silinirse o kategoriye sahip ürünler hala sahipmiş gibi durur. el ile düzeltmek gerekir.
            modelBuilder.Entity<Category>().HasMany(x => x.Products)
                                           .WithOne(x => x.Category)
                                           .HasForeignKey(x => x.CategoryId)
                                           .OnDelete(DeleteBehavior.NoAction);
            */

            /*
            //SetNull -> Kategori silinirse o kategoriye sahip ürünlerin kategori Id'si null olur.
            modelBuilder.Entity<Category>().HasMany(x => x.Products)
                                           .WithOne(x => x.Category)
                                           .HasForeignKey(x => x.CategoryId)
                                           .OnDelete(DeleteBehavior.SetNull);
            */

            //------------------------------------------------

            //One-To-Many
            //Her zaman Has ile başlanacak ardından With kullanacağız.
            //modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);

            //One-To-One
            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.ProductId);
            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);

            /*
            //Many-To-Many
            modelBuilder.Entity<Student>()
                .HasMany(x => x.Teachers)
                .WithMany(x => x.Students)
                .UsingEntity<Dictionary<string,object>>("StudentTeacherManyToMany",
                                                        x => x.HasOne<Teacher>()
                                                        .WithMany().HasForeignKey("TeacherIdNo")
                                                        .HasConstraintName("FK__TeacherId"),
                                                        x => x.HasOne<Student>()
                                                        .WithMany().HasForeignKey("StudentIdNo").
                                                        HasForeignKey("FK__StudentId")
                                                        );
            */

            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
