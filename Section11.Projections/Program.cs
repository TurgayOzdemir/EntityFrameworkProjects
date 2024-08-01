
using Section11.Projections.DAL;

using (var _context = new AppDbContext())
{

    var products = _context.Products.ToList();


    /*
    var category1 = new Category() { Name = "Kalemler" };

    category1.Products.Add(new Product()
    {
        Name = "Kalem 1",
        Price = 10,
        Stock = 100,
        Barcode = 1000,
        ProductFeature = new() { Color = "Blue", Height = 10, Width = 1 }
    });
    category1.Products.Add(new Product()
    {
        Name = "Kalem 2",
        Price = 12,
        Stock = 200,
        Barcode = 1001,
        ProductFeature = new() { Color = "Green", Height = 10, Width = 1 }
    });
    category1.Products.Add(new Product()
    {
        Name = "Kalem 3",
        Price = 15,
        Stock = 300,
        Barcode = 1010,
        ProductFeature = new() { Color = "Red", Height = 10, Width = 1 }
    });

    var category2 = new Category() { Name = "Silgiler" };

    category2.Products.Add(new Product()
    {
        Name = "Silgi 1",
        Price = 1,
        Stock = 250,
        Barcode = 1011,
        ProductFeature = new() { Color = "Blue", Height = 1, Width = 1 }
    });
    category2.Products.Add(new Product()
    {
        Name = "Silgi 2",
        Price = 5,
        Stock = 150,
        Barcode = 1100,
        ProductFeature = new() { Color = "Green", Height = 2, Width = 2 }
    });
    category2.Products.Add(new Product()
    {
        Name = "Silgi 3",
        Price = 7,
        Stock = 350,
        Barcode = 1101,
        ProductFeature = new() { Color = "Yellow", Height = 3, Width = 3 }
    });

    _context.Categories.Add(category1);
    _context.Categories.Add(category2);
    _context.SaveChanges();
    */
}