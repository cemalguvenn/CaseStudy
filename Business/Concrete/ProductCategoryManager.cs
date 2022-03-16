using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductCategoryManager : IProductCategoryService
    {
        private readonly IProductCategoryDal _productCategoryDal;

        public ProductCategoryManager(IProductCategoryDal productCategoryDal)
        {
            _productCategoryDal = productCategoryDal ?? throw new ArgumentNullException(nameof(productCategoryDal));
        }

        public async Task Add(ProductCategory productCategory)
        {
           await _productCategoryDal.Add(productCategory);
        }

        public async Task Delete(int id)
        {
            await _productCategoryDal.Delete(id);
        }

        public async Task<List<ProductCategory>> GetAll()
        {
            return await _productCategoryDal.GetAll();
        }

        public async Task<ProductCategory> GetByName(string name)
        {
            return await _productCategoryDal.GetByName(name);
        }

        public async Task Update(ProductCategory productCategory)
        {
            await _productCategoryDal.Update(productCategory);
        }
    }
}
