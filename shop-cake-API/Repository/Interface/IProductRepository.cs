using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop_cake_API.Models;

namespace shop_cake_API.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIDAsync(int id);
        Task InsertProductAsync(Product product);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);
        Task SaveAsync();
    }
}
