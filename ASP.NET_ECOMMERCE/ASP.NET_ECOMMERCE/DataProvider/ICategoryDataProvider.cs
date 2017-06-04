using System.Collections.Generic;
using ASP.NET_ECOMMERCE.Models;

namespace ASP.NET_ECOMMERCE.DataProvider
{
    public interface ICategoryDataProvider
    {
        Category GetCategoryById(int? id);
        void SaveCategory(Category category);
        void DeleteCategory(int id);
        ICollection<Category> GetAllCategories();
    }
}
