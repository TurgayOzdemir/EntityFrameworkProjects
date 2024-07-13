using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section07.Inheritance.DAL
{
    public class AppDbContext : DbContext
    {
        //Eğer BasePerson tablosunu da eklersek sadece 1 tablo oluşur. Sahip olmadığı özlellikler null atanır.
        public DbSet<BasePerson> Persons { get; set; } //
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(x => x.Salary).HasPrecision(8,2);

            base.OnModelCreating(modelBuilder);
        }

    }
}
