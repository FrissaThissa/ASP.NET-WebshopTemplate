using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebshopTemplate.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Categories")]
        [JsonIgnore]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [ForeignKey("Brands")]
        [JsonIgnore]
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string? Size { get; set; }
        //public List<string>? Images { get; set; }
        public List<Image>? Images { get; set; }

        [JsonIgnore]
        public List<Wishlist>? Wishlists { get; set; }

        [FromForm]
        [NotMapped]
        [JsonIgnore]
        public IFormFileCollection? Files { get; set; }
    }
}
