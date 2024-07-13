
using Section07.Inheritance.DAL;

using (var _context = new AppDbContext())
{
    var managers = _context.Managers.ToList();
    var employees = _context.Employees.ToList();
    var person = _context.Persons.ToList();

    person.ForEach(p =>
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

    Console.WriteLine("Kaydedildi");
}
