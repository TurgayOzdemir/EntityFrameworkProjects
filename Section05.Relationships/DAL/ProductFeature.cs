using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section05.Relationships.DAL
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }

        //EFCore ProductId tanımlamazsak ProductFeature'ı child class olarak algılayamıyor. One-To-One
        public int ProductId { get; set; }

        //[ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
