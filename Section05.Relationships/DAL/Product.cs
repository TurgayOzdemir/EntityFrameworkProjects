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
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] // Ototmatik değer almayı kapatır.
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Kdv { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }
        public decimal PriceKdv { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)] //Insert ve Update işlemlerinde hiçbir şekilde buna dokunma
        //public DateTime? LastAccessDate { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Veritabanına insert ettiğimizde bu değeri alır ama. update ederken bu değere karışmaz
        //public DateTime? CreatedDate { get; set; } = DateTime.Now;

        //public int? CategoryId { get; set; }
        //public Category? Category { get; set; }

        //public ProductFeature ProductFeature { get; set; }



        /*
        public int CategoryId { get; set; }

        //Navigation Property
        //[ForeignKey("CategoryId")]
        public Category Category { get; set; }


        //Shadow Property
        */
    }
}
