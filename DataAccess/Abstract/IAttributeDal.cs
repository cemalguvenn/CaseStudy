using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAttributeDal
    {
        Task Add(Entities.Concrete.Attribute attribute);
        Task Update(Entities.Concrete.Attribute attribute);
        Task Delete(int id);
        Task<List<Entities.Concrete.Attribute>> GetAll();
    }
}
