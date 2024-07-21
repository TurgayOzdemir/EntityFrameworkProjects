using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section09.QuerySection.Models
{
    public class ProductWithFeature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; } = null!;
        public int Height { get; set; }
    }
}
