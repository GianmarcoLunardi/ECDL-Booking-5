using Identity2.Data;
using Identity2.Models.Identity;
using Identity2.Service.Interface;
using Identity2.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2.Service.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        internal DbSet<Class> TabellaClass;


        public async Task Add(Class entity)
        {   // riguardar e 
            TabellaClass.Add(entity);
            await _ApplicationDbContext.SaveChangesAsync();

        }

        public Task<IEnumerable<Class>> All(PageInfo page = null)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Class> Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Class> FindInclude(Guid id, string Inclu = null)
        {
            throw new NotImplementedException();
        }
    }
}
