
using Microsoft.EntityFrameworkCore;
using Section13.Isolation.DAL;

using (var _context = new AppDbContext())
{

    using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.Snapshot))
    {
        var products1 = _context.Products.AsNoTracking().ToList(); ;

        var products2 = _context.Products.AsNoTracking().ToList(); ;

        transaction.Commit();
    }



    //-----------------------------------------------------------------


    /*
    using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.Serializable)) //Okuma yaparken Insert delete update gibi işlemler yapılamaz.
    {
        var products = _context.Products.Take(2).ToList();

        transaction.Commit();
    }
    */


    //------------------------------------------------------------------



    /*
    using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead)) //Okuma yaparken delete update gibi işlemler yapılamaz.
    {
        var products = _context.Products.Take(2).ToList();

        transaction.Commit();
    }
    */



    //--------------------------------------------------------------------


    /*
    using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
    {
        var product = _context.Products.First();
        product.Price = 1000;
        _context.SaveChanges();

        transaction.Commit();
    }
    */



    //------------------------------------------------------------------------


    /*
    using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
    {
        var product = _context.Products.First();
        product.Price = 3000;
        _context.SaveChanges();

        transaction.Commit();
        Console.WriteLine();
    }
    */
}
