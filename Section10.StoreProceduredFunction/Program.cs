
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Section10.StoreProceduredFunction.DAL;

using (var _context = new AppDbContext())
{

    //Where ifadesi kullanılabilir.
    var product = _context.GetProductWithFeatures(1).ToList();
    Console.WriteLine();


    //------------------------------------------------



    /*
        CREATE FUNCTION fc_product_full_with_param(@categoryId int)
        RETURNS TABLE
        AS
        RETURN
        (
        SELECT p.Id, p.Name, pf.Width, pf.Height FROM Products p
        LEFT JOIN ProductFeatures pf ON pf.Id = p.Id
        WHERE p.CategoryId = @categoryId
        )

        SELECT * FROM fc_product_full_with_param(1)
     */

    //int categoryId = 1;
    //var products = await _context.ProductWithFeatures.FromSqlInterpolated($"SELECT * FROM fc_product_full_with_param({categoryId})").ToListAsync();

    //Console.WriteLine();

    //--------------------------------------------------------


    // ToFunction("fc_product_full");
    //var products = await _context.ProductFulls.ToListAsync();

    //Console.WriteLine();

    //---------------------------------------------------------


    /* SQL QUERY
    CREATE PROCEDURE sp_insert_product
    @name nvarchar(max),
    @price decimal(8, 2),
    @stock int,
    @barcode int,
    @categoryId int,
    @newId int OUTPUT
    AS
    BEGIN
    INSERT INTO Products(Name, Price, Stock, Barcode, CategoryId) VALUES(@name, @price, @stock, @barcode, @categoryId)
    SET @newId = SCOPE_IDENTITY()
    RETURN @newId
    END

    DECLARE @newId int

    EXEC sp_insert_product "Kalem 4", 9, 100, 1110, 1, @newId OUTPUT

    SELECT @newId
    */

    /*
    var product = new Product { Name = "Kalem 5", Price = 10, Stock = 200, Barcode = 1111, CategoryId = 1};

    var newProductId = new SqlParameter("@newId", System.Data.SqlDbType.Int);
    newProductId.Direction = System.Data.ParameterDirection.Output;

    await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC sp_insert_product {product.Name}, {product.Price}, {product.Stock}, {product.Barcode}, {product.CategoryId}, {newProductId} out");

    var id = newProductId.Value;

    Console.WriteLine();
    */


    //-------------------------------------------------


    /*
    int categoryId = 2;
    decimal price = 4;

    var products = await _context.ProductFulls.FromSqlRaw($"EXEC sp_get_product_full_param {categoryId},{price}").ToListAsync();

    Console.WriteLine();
    */


    //---------------------------------------------------


    //var products = await _context.ProductFulls.FromSqlRaw("EXEC sp_get_product_full").ToListAsync();

    //Console.WriteLine();


    //---------------------------------------------------


    //var products = await _context.Products.FromSqlRaw("EXEC sp_get_products").ToListAsync();

    //Console.WriteLine();

    /*
    var category1 = new Category() { Name = "Kalemler" };

    category1.Products.Add(new Product() { Name = "Kalem 1", Price = 10, Stock = 100, Barcode = 1000, 
        ProductFeature = new() { Color = "Blue", Height = 10, Width = 1 } });
    category1.Products.Add(new Product() { Name = "Kalem 2", Price = 12, Stock = 200, Barcode = 1001, 
        ProductFeature = new() { Color = "Green", Height = 10, Width = 1 } });
    category1.Products.Add(new Product() { Name = "Kalem 3", Price = 15, Stock = 300, Barcode = 1010, 
        ProductFeature = new() { Color = "Red", Height = 10, Width = 1 } });

    var category2 = new Category() { Name = "Silgiler" };

    category2.Products.Add(new Product() { Name = "Silgi 1", Price = 1, Stock = 250, Barcode = 1011, 
        ProductFeature = new() { Color = "Blue", Height = 1, Width = 1 } });
    category2.Products.Add(new Product() { Name = "Silgi 2", Price = 5, Stock = 150, Barcode = 1100, 
        ProductFeature = new() { Color = "Green", Height = 2, Width = 2 } });
    category2.Products.Add(new Product() { Name = "Silgi 3", Price = 7, Stock = 350, Barcode = 1101, 
        ProductFeature = new() { Color = "Yellow", Height = 3, Width = 3 } });

    _context.Categories.Add(category1);
    _context.Categories.Add(category2);
    _context.SaveChanges();

    Console.WriteLine("Ürünler Kaydedildi");
    */
}
