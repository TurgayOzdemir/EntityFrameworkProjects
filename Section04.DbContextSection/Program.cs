
using Microsoft.EntityFrameworkCore;
using Section04.DbContextSection.DAL;

Initializer.Build();

using (var _context = new AppDbContext())
{






    //-------------------------------------



    /*
    //İlk datayı döner. Eğer yoksa exception fırlatır.
    var product1 = _context.Products.First(x => x.Id == 3);

    //İlk datayı döner. Eğer yoksa null döner
    var product2 = _context.Products.FirstOrDefault(x => x.Id == 3); //2. parametrede null olma durumunda obje ekleyebiliyoruz

    //Birden fazla data gelirse exception fırlatır. Tek bir data varsa o datayı çeker
    var product3 = _context.Products.Single(x => x.Id > 3);

    //Birden fazla data gelirse null fırlatır. Tek bir data varsa o datayı çeker
    var product4 = _context.Products.SingleOrDefault(x => x.Id > 3);

    //Koşulu sağlayan datalar liste şeklinde döner
    var product5 = _context.Products.Where(x => x.Id == 3).ToList();

    //Primary key ile datayı çekeriz
    var product6 = _context.Products.Find(5);
    */



    //-------------------------------------



    /*
    //SaveChanges() metodunu AppDbContexte override ettik.
    //SaveChanges() çağrıldığında Product'ın CreatedDate'i atanıyor database'e yansıtılıyor.
    _context.Products.Add(new() { Name = "Şapka", Price = 500, Stock = 1, Barcode = 4 });
    _context.Products.Add(new() { Name = "Eldiven", Price = 300, Stock = 3, Barcode = 5 });
    _context.Products.Add(new() { Name = "Ayakkabı", Price = 200, Stock = 14, Barcode = 6 });

    Console.WriteLine("Context ID: " + _context.ContextId);

    _context.SaveChanges();
    */



    //-------------------------------


    /* ChangeTracker
    var products = await _context.Products.ToListAsync();

    //Track edilen dataların içinde gezmek için
    _context.ChangeTracker.Entries().ToList().ForEach(e =>
    {
        if (e.Entity is Product p) // Data Product ise
        {
            Console.WriteLine(p.Name);
        }
    });

    _context.SaveChanges();
    */



    //---------------------------------



    /* AsNoTracking()
    //Gelen data EFCore tarfından track edilmez. Sadece Listeleme işlemi yapılacaksa mantıklı.
    //Değişiklik yapılamaz
    var products = await _context.Products.AsNoTracking().ToListAsync();

    products.ForEach(p =>
    {
        p.Stock += 100;
    });

    _context.SaveChanges();
    */



    //------------------




    /*
    // Entity Framework tarfından track edilmeyen bir nesneyi güncellemek istersek Update kullanıyoruz.
    _context.Update(new Product() { Id = 2, Name = "Küçük Defter", Price = 500, Stock = 40, Barcode = 963 });

    await _context.SaveChangesAsync();
    */



    //----------------------------------


    /* State => Deleted
    var product = await _context.Products.FirstAsync();

    Console.WriteLine(product.Name);

    Console.WriteLine("İlk State: " + _context.Entry(product).State); //Unchanged

    _context.Remove(product);

    Console.WriteLine("Silindikten sonraki State : " + _context.Entry(product).State); // Deleted

    await _context.SaveChangesAsync();

    Console.WriteLine("Kaydettikten sonraki State: " + _context.Entry(product).State); // Unchanged
    /*



    //----------------------------



    /* State => Modified
    var product = await _context.Products.FirstAsync();

    Console.WriteLine(product.Name);

    Console.WriteLine("İlk State: " + _context.Entry(product).State); //Unchanged

    product.Stock = 1000;

    Console.WriteLine("Güncellendikten sonraki State : " + _context.Entry(product).State); // Modified

    await _context.SaveChangesAsync();

    Console.WriteLine("Kaydettikten sonraki State: " + _context.Entry(product).State); // Unchanged
    */


    //--------------


    /* State => Added
    var newProduct = new Product { Name = "Cetvel", Price = 500, Stock = 66, Barcode = 852};

    Console.WriteLine("İlk State: " + _context.Entry(newProduct).State); //Detached

    //_context.Entry(newProduct).State = EntityState.Added; //Aşağıdaki ile aynı
    await _context.AddAsync(newProduct);

    Console.WriteLine("Ekledikten sonraki State: " + _context.Entry(newProduct).State); //Added

    await _context.SaveChangesAsync();

    Console.WriteLine("Kaydettikten sonraki State: " + _context.Entry(newProduct).State); // Unchanged
    */


    //------------------------------------


    /* State => Unchanged
    var products = await _context.Products.ToListAsync();

    products.ForEach(p =>
    {
        var state = _context.Entry(p).State;

        Console.WriteLine($"{p.Id} : {p.Name} / {state}");
    });
    */
}
