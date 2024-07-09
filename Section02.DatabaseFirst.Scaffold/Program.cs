
//Scaffold-DbContext "Data Source=TURGI\SQLEXPRESS;Initial Catalog=UdemyEFCoreDatabaseFirstDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

using Microsoft.EntityFrameworkCore;
using Section02.DatabaseFirst.Scaffold.Models;

using (var _context = new UdemyEfcoreDatabaseFirstDbContext())
{
    var products = await _context.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} : {p.Name} / {p.Price} / {p.Stock}");
    });
}