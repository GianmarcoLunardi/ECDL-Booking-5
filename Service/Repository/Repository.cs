using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Identity2.Service.Interface;
using Identity2.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Identity2.Service.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        readonly private DbContext ContextData;
        internal DbSet<T> DataSet;

        public Repository(DbContext contextData)
        {
            ContextData = contextData;
            this.DataSet  = ContextData.Set<T>();

        }

        public void Add(T entity)
        {
            DataSet.Add(entity);
            //throw new NotImplementedException();
        }

        public T Get(Guid id)
        {
            return DataSet.Find(id);  
            //throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, PageInfo page = null)
        {
            IQueryable<T> query = DataSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            //include properties will be comma seperated
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = DataSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            //include properties will be comma seperated
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            T eliminare = DataSet.Find(id);
        }

        public void Remove(T entity)
        {
            ContextData.Remove<T>(entity);
           
        }
    }
}
//throw new NotImplementedException();