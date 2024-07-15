using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section08.ModelSection.DAL
{
    public class Product
    {
        public int Id { get; set; }

        //[Unicode(false)] //Name varchar oldu. (varchar 1 byte yer tutarken nvarchar 2 byte yer tutuyor
        public string Name { get; set; } = null!;

        //[Column(TypeName = "nvarchar(200)")]
        public string Url { get; set; } = null!;

        //[Precision(18,2)] // ################,##
        public decimal Price { get; set; }
        public int Stock { get; set; }

        //[NotMapped] Tabloda stün olarak oluşturmaz.
        public int Barcode { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ProductFeature ProductFeature { get; set; }
    }
}
