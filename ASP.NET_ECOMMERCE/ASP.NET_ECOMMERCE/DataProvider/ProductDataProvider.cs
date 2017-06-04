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
        private readonly IDataService<Product> _dataServiceCreator;

        public ProductDataProvider(IDataService<Product> dataServiceCreator)
        {
            _dataServiceCreator = dataServiceCreator;
        }

        public Product GetRelationshipById(int? id)
        {


            return _dataServiceCreator.GetById(id.Value);

        }

        public void SaveProduct(Product product)
        {

            _dataServiceCreator.Save(product);

        }

        public void DeleteProduct(int id)
        {

            _dataServiceCreator.Delete(id);

        }

        public ICollection<Product> GetAllProducts()
        {

            return _dataServiceCreator.GetAll();

        }
    }
}