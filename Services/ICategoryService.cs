using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECart.Models;

namespace ECart.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);

    }
}