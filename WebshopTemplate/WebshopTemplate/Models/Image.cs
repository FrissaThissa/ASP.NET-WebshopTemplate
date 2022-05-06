﻿using System.ComponentModel.DataAnnotations;

namespace WebshopTemplate.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public byte[] Bytes { get; set; }
        public string Description { get; set; }
        public string FileExtension { get; set; }
        public decimal Size { get; set; }
        public string Base64 { get; set; }
    }
}
