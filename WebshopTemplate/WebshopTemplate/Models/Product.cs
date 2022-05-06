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
        public List<Image>? Images { get; set; }

        [FromForm]
        [NotMapped]
        public IFormFileCollection Files { get; set; }
    }
}
