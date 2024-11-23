using ECart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECart.DBAccess;
using System.Data.Entity;

namespace ECart.Services
{
    public class CategoryService : ICategoryService
    {
        private ECartDBContext _dbContext;

        public CategoryService(ECartDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _dbContext.CategoryTable.ToList();
        }
        public Category GetCategoryById(int id)
        {
            return _dbContext.CategoryTable.Find(id);
        }

        public void CreateCategory(Category category)
        {
            _dbContext.CategoryTable.Add(category);
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _dbContext.CategoryTable.Find(id);
            if(category!=null)
            {
                _dbContext.CategoryTable.Remove(category);
                _dbContext.SaveChanges();
            }
        }



    }
}