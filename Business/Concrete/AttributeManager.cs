using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AttributeManager : IAttributeService
    {
        private readonly IAttributeDal _attributeDal;

        public AttributeManager(IAttributeDal attributeDal)
        {
            _attributeDal = attributeDal ?? throw new ArgumentNullException(nameof(attributeDal));
        }

        public async Task Add(Entities.Concrete.Attribute attribute)
        {
            await _attributeDal.Add(attribute);
        }

        public async Task Delete(int id)
        {
            await _attributeDal.Delete(id);
        }

        public async Task<List<Entities.Concrete.Attribute>> GetAll()
        {
            return await _attributeDal.GetAll();
        }

        public async Task Update(Entities.Concrete.Attribute attribute)
        {
            await _attributeDal.Update(attribute);
        }
    }
}
