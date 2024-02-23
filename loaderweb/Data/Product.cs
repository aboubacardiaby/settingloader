using System.ComponentModel.DataAnnotations;

namespace loaderweb.Data
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } = 0;
    }
}
