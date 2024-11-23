using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECart.Models;

namespace ECart.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(int page, int pageSize, out int totalProducts);
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        IEnumerable<Category> GetAllCategories();
    }
}