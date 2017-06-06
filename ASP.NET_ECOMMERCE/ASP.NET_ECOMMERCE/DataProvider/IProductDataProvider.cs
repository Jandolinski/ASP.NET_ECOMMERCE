using System.Collections.Generic;
using ASP.NET_ECOMMERCE.Models;

namespace ASP.NET_ECOMMERCE.DataProvider
{
    public interface IProductDataProvider
    {
        Product GetRelationshipById(int? id);
        void SaveProduct(Product product);
        void DeleteProduct(int id);
        Product GetByName(string name);
        ICollection<Product> GetAllProducts();
    }
}
