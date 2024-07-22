using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section09.QuerySection.Models
{
    public class ProductFull
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
