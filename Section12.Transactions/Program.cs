
using Section12.Transactions.DAL;

using (var _context = new AppDbContext())
{

    var category = new Category() { Name = "Telefonlar" };

    _context.Categories.Add(category);


    throw new Exception();


    var product = _context.Products.First();

    product.Name = "Defter 123";


    _context.SaveChanges();

    Console.WriteLine();
}
