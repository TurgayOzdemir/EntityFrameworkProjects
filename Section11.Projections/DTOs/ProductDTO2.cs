using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section11.Projections.DTOs
{
    public class ProductDTO2
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal TotalPrice { get; set; }
        public int? TotalWidth { get; set; }
    }
}
