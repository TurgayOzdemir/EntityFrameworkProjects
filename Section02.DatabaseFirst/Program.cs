
using Microsoft.EntityFrameworkCore;
using Section02.DatabaseFirst.DAL;

using (var _context = new AppDbContext())
{
    var products = await _context.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} : {p.Name}");
    });
}
