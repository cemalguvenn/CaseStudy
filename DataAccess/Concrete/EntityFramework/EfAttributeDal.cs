using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAttributeDal : IAttributeDal
    {
        private readonly CaseDBContext _context;

        public EfAttributeDal(CaseDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Entities.Concrete.Attribute attribute)
        {
            try
            {
                await _context.Attributes.AddAsync(attribute);
            }
            catch (Exception error)
            {

                throw new Exception($"Something went wrong ", error);
            }
        }

        public async Task Delete(int id)
        {
            var attributeToDelete = await _context.Attributes.FirstOrDefaultAsync(x => x.AttributeId == id);
            attributeToDelete.IsDeleted = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception error)
            {

                throw new Exception($"Something went wrong trying to delete {attributeToDelete.Name}", error);
            }
        }

        public async Task<List<Entities.Concrete.Attribute>> GetAll()
        {
            var result = _context.Attributes.Where(a => a.IsDeleted == false).ToListAsync();
            return await result;
        }

        public async Task Update(Entities.Concrete.Attribute attribute)
        {
            var attributeToUpdate = await _context.Attributes.SingleOrDefaultAsync(x => x.AttributeId == attribute.AttributeId);
            attributeToUpdate.Name = attribute.Name;
            attributeToUpdate.Value = attribute.Value;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception error)
            {

                throw new Exception($"Something went wrong Updating {attribute.Name}", error);
            }
        }
    }
}
