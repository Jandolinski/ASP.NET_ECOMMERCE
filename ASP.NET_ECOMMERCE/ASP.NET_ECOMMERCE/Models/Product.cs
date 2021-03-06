﻿using System.ComponentModel.DataAnnotations;

namespace ASP.NET_ECOMMERCE.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public int ProducerId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Producer Producer { get; set; }
    }
}