using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET_ECOMMERCE.Models;
using ASP.NET_ECOMMERCE.Services;

namespace ASP.NET_ECOMMERCE.DataProvider
{
    public class CategoryDataProvider : ICategoryDataProvider
    {
        private readonly IDataService<Category> _dataServiceCreator;

        public CategoryDataProvider(IDataService<Category> dataServiceCreator)
        {
            _dataServiceCreator = dataServiceCreator;
        }

        public void DeleteCategory(int id)
        {

            _dataServiceCreator.Delete(id);

        }

        public ICollection<Category> GetAllCategories()
        {

            return _dataServiceCreator.GetAll();

        }

        public Category GetCategoryById(int? id)
        {

            return _dataServiceCreator.GetById(id.Value);

        }

        public void SaveCategory(Category category)
        {

            _dataServiceCreator.Save(category);

        }
    }
}