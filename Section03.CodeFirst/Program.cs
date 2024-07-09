
using Microsoft.EntityFrameworkCore;
using Section03.CodeFirst.DAL;

// add-migration initial => Migration oluşturur
// update-database => Migration'ı database'e uygular.

//Remove-Migration => Son migration'ı siler.
//update-database UpdateBarcode_ForProduct => seçilen migration'a döner
//script-migration => yapılan tüm değişikliklerin sql sorgusunu verir

Initializer.Build();

using (var _context = new AppDbContext())
{
    var products = await _context.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} : {p.Name} / {p.Price} / {p.Stock}");
    });
}
