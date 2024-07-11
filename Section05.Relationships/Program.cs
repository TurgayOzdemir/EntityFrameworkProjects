
using Section05.Relationships.DAL;

using (var _context = new AppDbContext())
{

    //Product -> Parent
    //ProductFeature -> Childed

    var category = _context.Categories.First(x => x.Name == "Silgiler");

    var product1 = new Product { Name = "Silgi 2", Price = 200, Stock = 200, Barcode = 132,
        Category = category,
        ProductFeature = new() { Color = "Red", Height = 100, Width = 100}    
    };

    var product2 = new Product { Name = "Silgi 4", Price = 200, Stock = 200, Barcode = 132,
        Category = category   
    };

    ProductFeature productFeature = new() { Color = "Blue", Height = 100, Width = 300, Product = product2 };

    _context.ProductFeature.Add(productFeature);
    //_context.Products.Add(product2);

    _context.SaveChanges();

    //------------------------------------------

    //var category = _context.Categories.First(x => x.Name == "Defterler");

    //var product = new Product() { Name = "Defter 3", Price = 100, Stock = 200, Barcode = 123, Category = category };

    /*
    var category = new Category() { Name = "Defterler" };

    //var product = new Product() { Name ="Kalem 1", Price = 100, Stock = 200, Barcode = 123, Category = category };

    category.Products.Add(new Product() { Name = "Defter 1", Price = 100, Stock = 200, Barcode = 123});
    category.Products.Add(new Product() { Name = "Defter 2", Price = 100, Stock = 200, Barcode = 123});
    //category.Products.AddRange();

    //_context.Products.Add(product);
    //_context.Add(product);
    */

    //category.Products.Add(product);

    //_context.SaveChanges();

    //------------------------------------------


    Console.WriteLine("Kaydedildi");
}