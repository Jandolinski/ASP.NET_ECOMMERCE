using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_ECOMMERCE.Models
{
    public class Producer
    {
        public int Id { get; set; }

        [Display(Name = "Producer's name")]
        [Required(ErrorMessage = "Producer's name is required")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}