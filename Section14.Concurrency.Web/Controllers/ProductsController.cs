using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Section14.Concurrency.Web.Models;
using System.Data;

namespace Section14.Concurrency.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _context.Products.FindAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(List));
            }
            catch (DbUpdateConcurrencyException exception)
            {
                var exceptionEntry = exception.Entries.First();

                var currentProduct = exceptionEntry.Entity as Product;
                var databaseValues = exceptionEntry.GetDatabaseValues();
                
                var clientValues = exceptionEntry.CurrentValues;

                if (databaseValues == null)
                {
                    ModelState.AddModelError(string.Empty, "Bu ürün başka bir kullanıcı tarafından silindi.");
                }
                else
                {
                    var databaseProduct = databaseValues.ToObject() as Product;
                    ModelState.AddModelError(string.Empty, "Bu ürün başka bir kullanıcı tarafından güncellendi.");
                    ModelState.AddModelError(string.Empty, $"Güncellenen Değer: Name:{databaseProduct.Name}, Price {databaseProduct.Price}, Stock: {databaseProduct.Stock}");
                }
                
                return View(product);
            }
            
        }

        public async Task<IActionResult> List()
        {
            return View(_context.Products.ToList());
        }
    }
}
