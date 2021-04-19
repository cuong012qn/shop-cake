using shop_cake_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace shop_cake_API.Repository
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private readonly ShopCakeDBContext _context;

        public ProductRepository(ShopCakeDBContext context)
        {
            _context = context;
        }

        public async void DeleteProduct(int id)
        {
            var product = await GetProductByIDAsync(id);
            _context.Products.Remove(product);
        }

        public async Task<Product> GetProductByIDAsync(int id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(x => x.ID.Equals(id));
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task InsertProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }


        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            //_context.Products.Update(product);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
