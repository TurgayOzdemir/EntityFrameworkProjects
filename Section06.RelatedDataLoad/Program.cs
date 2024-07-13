
using Microsoft.EntityFrameworkCore;
using Section06.RelatedDataLoad.DAL;


using (var _context = new AppDbContext())
{
    //var category = new Category() { Name = "Kalemler" };

    //category.Products.Add(new Product() { Name = "Kalem 1", Price = 100, Stock = 10, Barcode = 123, 
    //    ProductFeature = new() { Color = "Red", Height = 100, Width = 100 } });
    //category.Products.Add(new Product() { Name = "Kalem 2", Price = 200, Stock = 20, Barcode = 132,
    //    ProductFeature = new() { Color = "Blue", Height = 300, Width = 200 } });

    //await _context.Categories.AddAsync(category);


    //Eager Loading -> Kategoriyi çekerken o kategoriye bağlı productları da çekmemizi sağlar.
    var categoryWithProducts = await _context.Categories.Include(x => x.Products).ThenInclude(x => x.ProductFeature).FirstAsync();//Eager Loading
    
    Console.WriteLine(categoryWithProducts.Name);
    Console.WriteLine(categoryWithProducts.Products[0].Name);
    Console.WriteLine(categoryWithProducts.Products[0].ProductFeature.Color);

    await _context.SaveChangesAsync();

    Console.WriteLine("Kaydedildi");
}