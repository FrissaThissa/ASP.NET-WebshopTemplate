using System.ComponentModel.DataAnnotations;

namespace WebshopTemplate.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Category ParentCategory { get; set; }
    }
}
