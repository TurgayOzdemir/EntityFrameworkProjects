
using Microsoft.EntityFrameworkCore;
using Section06.RelatedDataLoad.DAL;


using (var _context = new AppDbContext())
{

    //Explicit Loading
    var category = _context.Categories.First();

    //Category'i çağırdığımızda Productlar gelmeyecek ama aşağıdaki bir durumda lazım olursa sonradan cetegory'nin Navigation propertysine productlar dahil olacak
    if (true)
    {
        _context.Entry(category).Collection(x => x.Products).Load();

        category.Products.ForEach(x =>
        {
            Console.WriteLine(x.Name);
        });
    }

    var product = _context.Products.First();

    //Product ve productFeature arasında one-to-one ilişki olduğu için Reference kullandık
    if (true)
    {
        _context.Entry(product).Reference(x => x.ProductFeature).Load();
    }



    //---------------------------------------------


    /*
    //var category = new Category() { Name = "Kalemler" };

    //category.Products.Add(new Product() { Name = "Kalem 1", Price = 100, Stock = 10, Barcode = 123, 
    //    ProductFeature = new() { Color = "Red", Height = 100, Width = 100 } });
    //category.Products.Add(new Product() { Name = "Kalem 2", Price = 200, Stock = 20, Barcode = 132,
    //    ProductFeature = new() { Color = "Blue", Height = 300, Width = 200 } });

    //await _context.Categories.AddAsync(category);


    //Eager Loading -> Kategoriyi çekerken o kategoriye bağlı productları da çekmemizi sağlar.
    var categoryWithProducts = await _context.Categories.Include(x => x.Products).ThenInclude(x => x.ProductFeature).FirstAsync();//Eager Loading
    //Include'daki x Kategoriyi işaret eder. Then Include kullandığımızda Kategorinin Productlarını işaret eder. Tekrar Include kullanırsak x kategori olur.

    Console.WriteLine(categoryWithProducts.Name);
    Console.WriteLine(categoryWithProducts.Products[0].Name);
    Console.WriteLine(categoryWithProducts.Products[0].ProductFeature.Color);

    await _context.SaveChangesAsync();
    */


    Console.WriteLine("Kaydedildi");
}