using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopTemplate.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Brand? Brand { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string? Size { get; set; }
        public List<Image>? Images { get; set; }

        public List<Cart>? Carts { get; set; }
        public List<Wishlist>? Wishlists { get; set; }

        [FromForm]
        [NotMapped]
        public IFormFileCollection? Files { get; set; }
    }
}
