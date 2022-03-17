using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        private readonly CaseDBContext _context;

        public EfProductDal(CaseDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Product product)
        {

            try
            {
                await _context.Products.AddAsync(product);
            }
            catch (Exception error)
            {

                throw new Exception($"Something went wrong ", error);
            }
        }

        public async Task Delete(int id)
        {
            var productToDelete = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            productToDelete.IsDeleted = true;
             
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception error)
            {

                throw new Exception($"Something went wrong trying to delete {productToDelete.Name}", error);
            }
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products
                .Where(p => p.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<List<Product>> GetByCategoryId(int categoryId)
        {
            var result = _context.Products
                 .Where(x => x.ProductCategoryId == categoryId && x.IsDeleted == false)
                 .ToListAsync();
            return await result;
        }

        public async Task<Product> GetById(int id)
        {
            var result = _context.Products
                .FirstOrDefaultAsync(x => x.Id == id);
            return await result;
        }

        public async Task<List<Product>> GetByPriceRange(int min, int max)
        {
            var result = _context.Products
                .Where(x => x.Price >= min && x.Price <= max && x.IsDeleted == false)
                .ToListAsync();
            return await result;
        }

        public async Task Update(Product product)
        {
            var productToUpdate = await _context.Products.SingleOrDefaultAsync(x => x.Id == product.Id);
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.ProductCategoryId = product.ProductCategoryId;
            productToUpdate.IsDeleted = product.IsDeleted;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception error)
            {

                throw new Exception($"Something went wrong Updating {product.Name}", error);
            }
        }
    }
}
