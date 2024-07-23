using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section10.StoreProceduredFunction.DAL
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
