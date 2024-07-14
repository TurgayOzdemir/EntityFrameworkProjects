
using Microsoft.EntityFrameworkCore;
using Section08.ModelSection.DAL;

using (var _context = new AppDbContext())
{

    var productFulls = _context.ProductFulls.FromSqlRaw(
        @"SELECT p.Id 'Product_Id', c.Name 'CategoryName', p.Name, p.Price, pf.Height FROM Products p
        JOIN ProductFeatures pf on p.Id = pf.Id
        JOIN Categories c on p.CategoryId = c.Id"
        ).ToList();

    /*
    var category = new Category() { Name = "Silgiler" };

    category.Products.Add(new Product()
    {
        Name = "Silgi 1",
        Price = 50,
        Stock = 110,
        Barcode = 147,
        ProductFeature = new() { Color = "Yellow", Width = 10, Height = 10 }
    });
    category.Products.Add(new Product()
    {
        Name = "Silgi 2",
        Price = 450,
        Stock = 220,
        Barcode = 258,
        ProductFeature = new() { Color = "Orange", Width = 20, Height = 20 }
    });
    category.Products.Add(new Product()
    {
        Name = "Silgi 3",
        Price = 13,
        Stock = 340,
        Barcode = 369,
        ProductFeature = new() { Color = "Blue", Width = 30, Height = 30 }
    });

    _context.Categories.Add(category);

    _context.SaveChanges();
    */

    Console.WriteLine("Kaydedildi");
}