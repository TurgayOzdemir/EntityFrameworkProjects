using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section08.ModelSection.DAL
{
    //[Keyless]
    public class ProductFull
    {
        public int Product_Id { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Height { get; set; }
    }
}
