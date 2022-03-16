using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductCategoryService
    {
        Task Add(ProductCategory productCategory);
        Task Update(ProductCategory productCategory);
        Task Delete(int id);
        Task<List<ProductCategory>> GetAll();
        Task<ProductCategory> GetByName(string name);
    }
}
