using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section05.Relationships.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ProductFeature ProductFeature { get; set; }



        /*
        public int CategoryId { get; set; }

        //Navigation Property
        //[ForeignKey("CategoryId")]
        public Category Category { get; set; }


        //Shadow Property
        */
    }
}
