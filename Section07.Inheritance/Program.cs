
using Section07.Inheritance.DAL;

using (var _context = new AppDbContext())
{

    //TABLE PER TABLE için Hem person hem employee hem de manager entitysi için tanlo oluştu ve one to one ilişki kurdu.
    //TABLE PER HIERARCY için persons dbsetini dahil edersek tek tablo etmezsek manager ve employee tablosu oluştu. oluşan tek tabloda Discriminator adında enitity adıyla ayıran bir stün da oluştu.

    //_context.Managers.Add(new Manager { FirstName = "Turgay", LastName = "Özdemir", Age = 24, Grade = 10 });
    //_context.Employees.Add(new Employee { FirstName = "Ahmet", LastName = "Mehmet", Age = 22, Salary = 17502 });

    var managers = _context.Managers.ToList();
    var employees = _context.Employees.ToList();
    var persons = _context.Persons.ToList();

    persons.ForEach(p =>
    {
        switch (p)
        {
            case Manager manager:
                Console.WriteLine($"Manager Entity : {manager.Grade}");
                break;
            case Employee employee:
                Console.WriteLine($"Employee Entity : {employee.Salary}");
                break;

            default:
                Console.WriteLine("Default");
                break;
        }
    });

    _context.SaveChanges();


    //-----------------------------------


    /* TABLE PER HIERARCY
    var managers = _context.Managers.ToList();
    var employees = _context.Employees.ToList();
    var persons = _context.Persons.ToList();

    persons.ForEach(p =>
    {
        switch (p)
        {
            case Manager manager:
                Console.WriteLine($"Manager Entity : {manager.Grade}");
                break;
            case Employee employee:
                Console.WriteLine($"Employee Entity : {employee.Salary}");
                break;

            default:
                break;
        }
    });

    //_context.Persons.Add(new Manager { FirstName = "Turgay", LastName = "Özdemir", Age = 24, Grade = 10 });
    //_context.Persons.Add(new Employee { FirstName = "Ahmet", LastName = "Mehmet", Age = 22, Salary = 17502 });

    _context.SaveChanges();
    */

    Console.WriteLine("Kaydedildi");
}
