
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Section12.Transactions.DAL;
using System.Data;
using System.Data.Common;

Initializer.Build();

var connection = new SqlConnection(Initializer.Configuration.GetConnectionString("SqlCon"));

IDbContextTransaction transaction = null;



using (var _context = new AppDbContext(connection))
{

    using (transaction = _context.Database.BeginTransaction())
    {
        var category = new Category() { Name = "Telefonlar" };

        _context.Categories.Add(category);

        _context.SaveChanges();


        var product = _context.Products.First();

        product.Name = "Defter 123";


        _context.SaveChanges();


        using (var dbContext2 = new AppDbContext(connection))
        {

            dbContext2.Database.UseTransaction(transaction.GetDbTransaction());

            var product2 = dbContext2.Products.First();

            product2.Stock = 100;
            dbContext2.SaveChanges();

        }


        transaction.Commit();

    }

    Console.WriteLine();


    ///---------------------------------------------------


    /*
    using (var transaction = _context.Database.BeginTransaction())
    {
        var category = new Category() { Name = "Telefonlar" };

        _context.Categories.Add(category);

        _context.SaveChanges();


        throw new Exception();


        var product = _context.Products.First();

        product.Name = "Defter 123";


        _context.SaveChanges();

        transaction.Commit(); //Bir işlem hata alsa bile tüm save changeler geri alınıyor.
    }
    */


    //-----------------------------------------------------



    /*
    var category = new Category() { Name = "Telefonlar" };

    _context.Categories.Add(category);


    throw new Exception();


    var product = _context.Products.First();

    product.Name = "Defter 123";


    _context.SaveChanges();

    Console.WriteLine();
    */
}
