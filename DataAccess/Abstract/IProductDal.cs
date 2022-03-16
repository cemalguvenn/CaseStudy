using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(int id);
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<List<Product>> GetByCategoryId(int categoryId);
        Task<List<Product>> GetByPriceRange(int min, int max);

    }
}
