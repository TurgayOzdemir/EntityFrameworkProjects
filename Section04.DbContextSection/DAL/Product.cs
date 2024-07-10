using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04.DbContextSection.DAL
{
    [Table("ProductTB", Schema = "products")] // Oluşacak tablonun ve şemanın adı DataAnnotations ile böyle değişiyor.
    public class Product
    {
        [Key] //Eğer Id harici isim verirsek DataAnnotation ile Primary key olduğunu bu şekilde işaretliyoruz
        public int Id { get; set; }

        [Column("Name2", TypeName = "nvarchar(50)", Order =3)] // Sütun özelliklerini DataAnnotation yoluyla verilme şekli bu şekilde.
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Stock { get; set; }
        public int? Barcode { get; set; }

    }
}
