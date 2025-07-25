﻿using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Category
    {
        public Category()
        {
            this.CategoryBooks = new HashSet<BookCategory>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<BookCategory> CategoryBooks { get; set; }
    }
}