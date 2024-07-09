
using Microsoft.EntityFrameworkCore;
using Section03.CodeFirst.DAL;

// add-migration initial => Migration oluşturur
// update-database => Migration'ı database'e uygular.

Initializer.Build();

using (var _context = new AppDbContext())
{
    var products = await _context.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} : {p.Name} / {p.Price} / {p.Stock}");
    });
}
