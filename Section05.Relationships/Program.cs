
using Section05.Relationships.DAL;

using (var _context = new AppDbContext())
{
    var category = _context.Categories.First(x => x.Name == "Defterler");

    var product = new Product() { Name = "Defter 3", Price = 100, Stock = 200, Barcode = 123, Category = category };

    /*
    var category = new Category() { Name = "Defterler" };

    //var product = new Product() { Name ="Kalem 1", Price = 100, Stock = 200, Barcode = 123, Category = category };

    category.Products.Add(new Product() { Name = "Defter 1", Price = 100, Stock = 200, Barcode = 123});
    category.Products.Add(new Product() { Name = "Defter 2", Price = 100, Stock = 200, Barcode = 123});
    //category.Products.AddRange();

    //_context.Products.Add(product);
    //_context.Add(product);
    */

    category.Products.Add(product);
    

    _context.SaveChanges();
    Console.WriteLine("Kaydedildi");
}