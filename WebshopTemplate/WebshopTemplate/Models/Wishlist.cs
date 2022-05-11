using System.ComponentModel.DataAnnotations;
using WebshopTemplate.Areas.Identity.Data;

namespace WebshopTemplate.Models
{
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }
        public List<Product>? Products { get; set; }
        public WebshopTemplateUser? User { get; set; }
    }
}
