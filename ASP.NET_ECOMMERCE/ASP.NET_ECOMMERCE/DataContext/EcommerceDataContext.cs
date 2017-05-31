using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ASP.NET_ECOMMERCE.Models;

namespace ASP.NET_ECOMMERCE.DataContext
{
    public class EcommerceDataContext : DbContext
    {
        public EcommerceDataContext() : base("Ecommerce")
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public System.Data.Entity.DbSet<ASP.NET_ECOMMERCE.Models.Producer> Producers { get; set; }
    }
}