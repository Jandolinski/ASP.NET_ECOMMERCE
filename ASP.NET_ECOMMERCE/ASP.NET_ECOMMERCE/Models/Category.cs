﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_ECOMMERCE.Models
{
    public class Category
    {

        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category name is required")]
        [MaxLength(45, ErrorMessage = "The category name can be maximum 45 characters long")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}