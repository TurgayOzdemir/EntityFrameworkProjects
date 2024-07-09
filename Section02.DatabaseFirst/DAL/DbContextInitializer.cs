using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02.DatabaseFirst.DAL
{
    public class DbContextInitializer
    {
        public static IConfigurationRoot Configuration;
        public static DbContextOptionsBuilder<AppDbContext> OptionsBuilder;

        public static void Build()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional:true, reloadOnChange: true);

            Configuration = builder.Build();

            //Burayı AppDbContext'deki OnConfiguring metodunun içine yazdık
            //OptionsBuilder = new DbContextOptionsBuilder<AppDbContext> ();
            //OptionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlCon"));
        }
    }
}
