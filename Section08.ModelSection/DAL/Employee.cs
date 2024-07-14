using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section08.ModelSection.DAL
{
    public class Employee
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public decimal Salary { get; set; }
    }
}
