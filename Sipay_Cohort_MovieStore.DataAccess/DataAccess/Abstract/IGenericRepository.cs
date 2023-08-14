using Sipay_Cohort_MovieStore.Core.Entities.Interfaces;
using Sipay_Cohort_MovieStore.Core.Utilities.Response;
using System.Linq.Expressions;

namespace Sipay_Cohort_MovieStore.DataAccess.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class,IEntity
    {
        Task<bool> Activate(int id);
        Task<List<T>> GetActive();
        Task<bool> Add(T entity); 
        T GetByID(int id);
        bool Remove(int id);
        bool Remove(T entity);
        bool Update(T entity);
    }
}
