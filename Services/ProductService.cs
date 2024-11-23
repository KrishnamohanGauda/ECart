using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECart.DBAccess;
using ECart.Models;
using System.Data.Entity;

namespace ECart.Services
{
    public class ProductService:IProductService
    {
        private ECartDBContext _dbContext;
        public ProductService(ECartDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProducts(int page, int pageSize, out int totalProducts)
        {
            totalProducts = _dbContext.ProductsTable.Count();
            return _dbContext.ProductsTable.Include(p => p.Category)
                                      .OrderBy(p => p.ProductId)
                                      .Skip((page - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToList();
        }
        public Product GetProductById(int id)
        {
            return _dbContext.ProductsTable.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
        }
        public void CreateProduct(Product product)
        {
            _dbContext.ProductsTable.Add(product);
            _dbContext.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _dbContext.ProductsTable.Find(id);
            if(product!=null)
            {
                _dbContext.ProductsTable.Remove(product);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _dbContext.CategoryTable.ToList();   
        }
    }
}