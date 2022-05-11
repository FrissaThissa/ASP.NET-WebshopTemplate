using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebshopTemplate.Areas.Identity.Data;

namespace WebshopTemplate.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public List<Cart_Product>? Products { get; set; }
        public WebshopTemplateUser? User { get; set; }
    }
}