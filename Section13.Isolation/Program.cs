
using Microsoft.EntityFrameworkCore;
using Section13.Isolation.DAL;

using (var _context = new AppDbContext())
{

    using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
    {
        var product = _context.Products.First();
        product.Price = 3000;
        _context.SaveChanges();

        transaction.Commit();
        Console.WriteLine();
    }

}
