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
        private readonly Func<IDataService<Category>> _dataServiceCreator;

        public CategoryDataProvider(Func<IDataService<Category>> dataServiceCreator)
        {
            _dataServiceCreator = dataServiceCreator;
        }

        public void DeleteCategory(int id)
        {
            using (var dataService = _dataServiceCreator())
            {
                dataService.Delete(id);
            }
        }

        public ICollection<Category> GetAllCategories()
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetAll();
            }
        }

        public Category GetCategoryById(int? id)
        {
            using (var dataService = _dataServiceCreator())
            {
                return dataService.GetById(id.Value);
            }
        }

        public void SaveCategory(Category category)
        {
            using (var dataService = _dataServiceCreator())
            {
                dataService.Save(category);
            }
        }
    }
}