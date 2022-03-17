using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductCategoryDal : IProductCategoryDal
    {
        private readonly CaseDBContext _context;

        public EfProductCategoryDal(CaseDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(ProductCategory productCategory)
        {
            try
            {
                await _context.ProductCategories.AddAsync(productCategory);
            }
            catch (Exception error)
            {

                throw new Exception($"Something went wrong ", error);
            }
        }

        public async Task Delete(int id)
        {
            var productCategoryToDelete = await _context.ProductCategories.FirstOrDefaultAsync(x => x.ProductCategoryId == id);
            productCategoryToDelete.IsDeleted = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception error)
            {

                throw new Exception($"Something went wrong trying to delete {productCategoryToDelete.Name}", error);
            }
        }

        public async Task<List<ProductCategory>> GetAll()
        {
            var result = _context.ProductCategories.Where(p => p.IsDeleted == false).ToListAsync();
            return await result;
        }

        public async Task<ProductCategory> GetByName(string name)
        {
            var result = _context.ProductCategories
                .Where(p => p.IsDeleted == false)
                .FirstOrDefaultAsync(x => x.Name == name);
            return await result;
        }

        public async Task Update(ProductCategory productCategory)
        {
            var productCategoryToUpdate = await _context.ProductCategories.SingleOrDefaultAsync(x => x.ProductCategoryId == productCategory.ProductCategoryId);
            productCategoryToUpdate.Name = productCategory.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception error)
            {

                throw new Exception($"Something went wrong Updating {productCategory.Name}", error);
            }
        }
    }
}
