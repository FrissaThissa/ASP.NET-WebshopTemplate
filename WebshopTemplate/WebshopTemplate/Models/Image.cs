using System.ComponentModel.DataAnnotations;

namespace WebshopTemplate.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string? Path { get; set; }
        public string? OriginalFileName { get; set; }
    }
}
