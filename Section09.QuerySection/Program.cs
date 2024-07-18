
using Section09.QuerySection.DAL;

using (var _context = new AppDbContext())
{
    var people = _context.People.ToList().Where(x => FormatPhone(x.Phone!) == "5332226699").ToList();

    var person = _context.People.ToList().Select(x => new { PersonName = x.Name, PersonPhone = FormatPhone(x.Phone!)}).ToList(); //İsimsiz Class

    Console.WriteLine("");

    //_context.People.Add(new() { Name = "Ahmet", Phone = "05332226699" });
    //_context.People.Add(new() { Name = "Mehmet", Phone = "05777226699" });
    //_context.People.Add(new() { Name = "Mahmut", Phone = "05992226699" });

    _context.SaveChanges();
}

string FormatPhone(string phone)
{
    return phone.Substring(1,phone.Length-1);
}