using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal ?? throw new ArgumentNullException(nameof(productDal));
        }

        public async Task Add(Product product)
        {
            await _productDal.Add(product);
        }

        public async Task Delete(int id)
        {
            await _productDal.Delete(id);
        }

        public async Task<List<Product>> GetAll()
        {
           return await _productDal.GetAll();
        }

        public async Task<List<Product>> GetByCategoryId(int categoryId)
        {
            return await _productDal.GetByCategoryId(categoryId);
        }

        public async Task<Product> GetById(int id)
        {
            return await _productDal.GetById(id);
        }

        public async Task<List<Product>> GetByPriceRange(int min, int max)
        {
            return await _productDal.GetByPriceRange(min, max);
        }

        public async Task Update(Product product)
        {
            await _productDal.Update(product);
        }
    }
}
