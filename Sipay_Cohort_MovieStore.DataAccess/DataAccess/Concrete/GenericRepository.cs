using Microsoft.EntityFrameworkCore;
using Sipay_Cohort_MovieStore.Core.Entities.Interfaces;
using Sipay_Cohort_MovieStore.DataAccess.Context;
using Sipay_Cohort_MovieStore.DataAccess.DataAccess.Abstract;
using System.Linq.Expressions;
using System.Transactions;

namespace Sipay_Cohort_MovieStore.DataAccess.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class,IEntity
    {
        private readonly MovieStoreDbContext _context;
        private readonly DbSet<T> _table;
        public GenericRepository(MovieStoreDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();

        }
        public async Task<bool> Activate(int id)
        {
            T item = GetByID(id);
            item.IsActive = true;
            return Update(item);
        }

        public async Task<bool> Add(T entity)
        {
            try
            {
                await _table.AddAsync(entity);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T GetByID(int id) => _table.Find(id);

        public IQueryable<T> GetByID(int id, params Expression<Func<T, object>>[] includes)
        {
            var query = _table.Where(x => x.Id == id);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public async Task<List<T>> GetActive() => await _table.Where(x => x.IsActive == true).ToListAsync();

        public bool Remove(T entity)
        {
            entity.IsActive = false;
            return Update(entity);
        }

        public bool Remove(int id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    T item = GetByID(id);
                    item.IsActive = false;
                    ts.Complete();
                    return Update(item);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _table.Update(entity);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
