using System.ComponentModel.DataAnnotations;

namespace WebshopTemplate.Models
{
    public class Cart_Product
    {
        [Key]
        public int Id { get; set; }
        public Product? Product { get; set; }
        public int Amount { get; set; }
    }
}