using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopTemplate.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [ForeignKey("Categories")]
        public int? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
    }
}
