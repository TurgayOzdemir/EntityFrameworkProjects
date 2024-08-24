using System.ComponentModel.DataAnnotations;

namespace Section14.Concurrency.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        //[Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
