
using Section12.Transactions.DAL;

using (var _context = new AppDbContext())
{

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
