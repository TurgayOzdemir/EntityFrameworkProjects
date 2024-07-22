
using Microsoft.EntityFrameworkCore;
using Section09.QuerySection.DAL;
using Section09.QuerySection.Models;
using System.Drawing;

List<Product> GetProducts(int page, int pageSize, AppDbContext _context)
{
    var products = _context.Products.OrderByDescending(x => x.Id).Skip(pageSize * (page-1)).Take(pageSize).ToList();

    return products;
}

using (var _context = new AppDbContext())
{

    //Take - Skip
    GetProducts(3, 3, _context).ForEach(x =>
    {
        Console.WriteLine($"ID: {x.Id} NAME: {x.Name}");
    });


    //-------------------------------------------



    /*
    //.ToView("vw_productWithFeature");
    var products = _context.ProductFulls.ToList();
    Console.WriteLine();
    */


    //------------------------------------------

    /*
    //.ToSqlQuery("Select Name, Price From Products");
    var products = _context.ProductEssentials.Where(x => x.Price > 10).ToList(); ;
    Console.WriteLine();
    */

    //-----------------------------------------



    /*
    var products = await _context.ProductEssentials.FromSqlRaw("select Name,Price from products").ToListAsync();

    //Yeni yöntem ile dto için db set yapmak zorunda değiliz.
    var productWithFeature = await _context.Set<ProductWithFeature>()
        .FromSqlRaw("SELECT p.Id, p.Name, p.Price, pf.Color, pf.Height FROM Products p INNER JOIN ProductFeatures pf on p.Id = pf.Id").ToListAsync();

    Console.WriteLine();
    */


    //-----------------------------------------

    /*/
    var id = 5;
    decimal price = 15;

    // FromSqlRaw
    var products = await _context.Products.FromSqlRaw("select * from products").ToListAsync();

    var product = await _context.Products.FromSqlRaw("select * from products where Id={0}", id).FirstAsync();

    var products2 = await _context.Products.FromSqlRaw("select * from products where Price>{0}", price).ToListAsync();

    //FromSqlInterpolated
    var products3 = await _context.Products.FromSqlInterpolated($"select * from products where Price>{price}").ToListAsync();

    Console.WriteLine();
    */


    //-----------------------------------



    /*
    //QUERY SYNTAX
    var leftJoin = await (from p in _context.Products
                          join pf in _context.ProductFeatures on p.Id equals pf.Id into pflist
                          from pf in pflist.DefaultIfEmpty()
                          select new
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Color = pf.Color
                          }).ToListAsync();


    var rightJoin = await (from pf in _context.ProductFeatures
                           join p in _context.Products on pf.Id equals p.Id into plist
                           from p in plist.DefaultIfEmpty()
                           select new
                           {
                               Id = p.Id,
                               Name = p.Name,
                               Color = pf.Color
                           }).ToListAsync();


    var outerJoin = leftJoin.Union(rightJoin);

    outerJoin.ToList().ForEach(x =>
    {
        Console.WriteLine(x.Id);
        Console.WriteLine(x.Name);
        Console.WriteLine(x.Color);
    });
    */


    //--------------------------------------------



    /*
    //Left join ve Right joinde sadece yerini değiştiriyoruz. 
    
    var leftJoin = await (from p in _context.Products
                        join pf in _context.ProductFeatures on p.Id equals pf.Id into pflist
                        from pf in pflist.DefaultIfEmpty()
                        select new { 
                            ProductName = p.Name,
                            ProductColor = pf.Color,
                            ProductWidth = (int?)pf.Width == null ? 0 : pf.Width
                        }).ToListAsync();
    

    var rightJoin = await ( from pf in _context.ProductFeatures
                            join p in _context.Products on pf.Id equals p.Id into plist
                            from p in plist.DefaultIfEmpty()
                            select new
                            {
                                ProductName = p.Name,
                                ProductColor = pf.Color,
                                ProductWidth = (int?)pf.Width == null ? 0 : pf.Width
                            }).ToListAsync();

    */


    //---------------------------------------------------------------



    //INNER JOIN

    /*//2'li Join
     * METHOD SYNTAX
    var result = _context.Categories.Join(_context.Products, x => x.Id, y => y.CategoryId, (c, p) => new
    {
        CategoryName= c.Name,
        ProductName= p.Name,
        ProductPrice = p.Price,
    }).ToList();

    //var result = _context.Categories.Join(_context.Products, x => x.Id, y => y.CategoryId, (c, p) => p).ToList(); //Sadece productları alır.


    var result = (from c in _context.Categories
                   join p in _context.Products on c.Id equals p.CategoryId
                   select new
                   {
                       CategoryName= c.Name,
                       ProductName = p.Name,
                       ProductPrice = p.Price
                   }).ToList();
    */

    /*//3'lü Join
    var result = _context.Categories.Join(_context.Products, c => c.Id, p => p.Id, (c, p) => new { c, p })
                                    .Join(_context.ProductFeatures, x => x.p.Id, y=> y.Id, (c,pf) => new
                                    {
                                        CategoryName = c.c.Name,
                                        ProductName = c.p.Name,
                                        ProductFeature = pf.Color,
                                    });

    var result = (from c in _context.Categories
                  join p in _context.Products on c.Id equals p.CategoryId
                  join pf in _context.ProductFeatures on p.Id equals pf.Id
                  select new
                  {
                      CategoryName = c.Name,
                      ProductName = p.Name,
                      ProductColor = pf.Color
                  });

    */

    /*
    Console.WriteLine();

    
    var category = new Category() { Name = "Defterler" };

    category.Products.Add(new()
    {
        Name = "Defter 4",
        Price = 3,
        Stock = 100,
        Barcode = 0111,
        ProductFeature = new() { Color = "Red", Width = 3, Height = 3 }
    });
    category.Products.Add(new()
    {
        Name = "Defter 5",
        Price = 7,
        Stock = 50,
        Barcode = 1000,
        ProductFeature = new() { Color = "Green", Width = 1, Height = 1 }
    });
    category.Products.Add(new()
    {
        Name = "Defter 6",
        Price = 1,
        Stock = 200,
        Barcode = 1001,
        ProductFeature = new() { Color = "Yellow", Width = 1, Height = 2 }
    });

    _context.Categories.Add(category);
    _context.SaveChanges();
    */



    //---------------------------------------------------------------



    /*
    var people = _context.People.ToList().Where(x => FormatPhone(x.Phone!) == "5332226699").ToList();

    var person = _context.People.ToList().Select(x => new { PersonName = x.Name, PersonPhone = FormatPhone(x.Phone!)}).ToList(); //İsimsiz Class

    Console.WriteLine("");

    //_context.People.Add(new() { Name = "Ahmet", Phone = "05332226699" });
    //_context.People.Add(new() { Name = "Mehmet", Phone = "05777226699" });
    //_context.People.Add(new() { Name = "Mahmut", Phone = "05992226699" });

    _context.SaveChanges();
    */
}

string FormatPhone(string phone)
{
    return phone.Substring(1,phone.Length-1);
}