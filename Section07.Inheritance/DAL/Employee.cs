using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section07.Inheritance.DAL
{
    public class Employee : BasePerson
    {
        public decimal Salary { get; set; }
    }
}
