using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity2.Data;
using Identity2.Models;
using Identity2.Service;
using Identity2.Service.Interface;

namespace Identity2.Service
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _BaseDati ;

        public GenericRepository(ApplicationDbContext baseDati)
        {
            _BaseDati = baseDati;
        }

        async Task IGenericRepository<T>.Add(T entity)
        {
             await _BaseDati.AddAsync<T>(entity);
             await _BaseDati.SaveChangesAsync();
            //throw new NotImplementedException();
        }


        async Task IGenericRepository<T>.Edit(T entity)
        {

            if (await _BaseDati.FindAsync<T>() is T found)
            {
                // found.Name = incoming.Name;
                // found.Age = incoming.Age;
                found = entity;

                await _BaseDati.SaveChangesAsync();
            }

            await _BaseDati.SaveChangesAsync();

            //throw new NotImplementedException();
        }
      
        async Task<IEnumerable<T>> IGenericRepository<T>.All()
        {



            return _BaseDati.Set<T>();



            



            // throw new NotImplementedException();
        }

        async Task IGenericRepository<T>.Delete(Guid id)
        {
            T x = await _BaseDati.FindAsync<T>(id);
            _BaseDati.Remove<T>(x);
            _BaseDati.SaveChangesAsync();
            
            //throw new NotImplementedException();
        }

         async Task<T> IGenericRepository<T>.Find(string id)
        {
            return await _BaseDati.FindAsync<T>(Guid.Parse(id));
        }

        async Task<T> IGenericRepository<T>.Find(Guid id)
        {
            return await _BaseDati.FindAsync<T>(id);
        }

        async Task<T> IGenericRepository<T>.FindInclude(Guid id, string Inclu = null)
        {
            throw new NotImplementedException();
        }
    }
}
