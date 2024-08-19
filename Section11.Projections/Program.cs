
using Microsoft.EntityFrameworkCore;
using Section11.Projections.DAL;
using Section11.Projections.DTOs;

using (var _context = new AppDbContext())
{

    var products = await _context.Products.Select(x => new ProductDTO
    {
        CategoryName = x.Category.Name,
        ProductName = x.Name,
        ProductPrice = x.Price,
        Width = (int?)x.ProductFeature.Width,
    }).Where(x => x.Width > 0).ToListAsync();

    var category = await _context.Categories.Select(x => new ProductDTO2
    {
        CategoryName = x.Name,
        ProductName = String.Join(",", x.Products.Select(z => z.Name)),
        TotalPrice = x.Products.Sum(y => y.Price),
        TotalWidth = (int?)x.Products.Select(k => k.ProductFeature.Width).Sum(),
    }).Where(x => x.TotalPrice > 0).ToListAsync();

    Console.WriteLine();


    //*-----------------------------------------------------


    /*
    var products = await _context.Products.Select(x => new
    {
        CategoryName = x.Category.Name,
        ProductName = x.Name,
        ProductPrice = x.Price,
        Width = (int?)x.ProductFeature.Width,
    }).Where(x => x.Width > 0 && x.ProductName.StartsWith("k")).ToListAsync();


    Console.WriteLine();
    */



    //-------------------------------------------------------



    /*
    var products = await _context.Products.Include(x => x.Category).Include(x => x.ProductFeature).Select(x => new
    {
        CategoryName = x.Category.Name,
        ProductName = x.Name,
        ProductPrice = x.Price,
        Width = (int?) x.ProductFeature.Width,
    }).Where(x => x.Width > 0 && x.ProductName.StartsWith("k")).ToListAsync();

    var categories = _context.Categories.Include(x => x.Products).ThenInclude(x => x.ProductFeature).Select(x => new
    {
        CategoryName = x.Name,
        Products = String.Join(",", x.Products.Select(z => z.Name)),
        TotalPrice = x.Products.Sum(x => x.Price)
    }).Where(y => y.TotalPrice > 100).OrderBy(x => x.TotalPrice).ToList();

    Console.WriteLine();
    */



    //--------------------------------------------------------


    //var products = _context.Products.ToList();


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