using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET_ECOMMERCE.Models;
using ASP.NET_ECOMMERCE.Services;

namespace ASP.NET_ECOMMERCE.DataProvider
{
    public class ProductDataProvider : IProductDataProvider
    {
        private readonly Func<IDataService<Product>> _dataServiceCreator;

        public ProductDataProvider(Func<IDataService<Product>> dataServiceCreator)
        {
            _dataServiceCreator = dataServiceCreator;
        }

        public Product GetRelationshipById(int? id)
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetById(id.Value);
            }
        }

        public void SaveProduct(Product product)
        {
            using (var dataService = _dataServiceCreator())
            {
                dataService.Save(product);
            }
        }

        public void DeleteProduct(int id)
        {
            using (var dataService = _dataServiceCreator())
            {
                dataService.Delete(id);
            }
        }

        public ICollection<Product> GetAllProducts()
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetAll();
            }
        }
    }
}