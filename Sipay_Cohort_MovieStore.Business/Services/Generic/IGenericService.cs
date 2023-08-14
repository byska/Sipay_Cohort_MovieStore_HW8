using Sipay_Cohort_MovieStore.Core.Utilities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Business.Services.Generic
{
    public interface IGenericService<TEntity, TRequest, TResponse>
    {
        Task<ApiResponse<bool>> Activate(int id);
        Task<ApiResponse<bool>> Add(TRequest entity);
        ApiResponse<TResponse> GetById(int id);
        Task<ApiResponse<List<TResponse>>> GetActive();
        Task<ApiResponse<List<TResponse>>> GetAllWithParameters(Expression<Func<TEntity, object>> include, params Expression<Func<TEntity, bool>>[] exps);
        ApiResponse<bool> Remove(TEntity entity);
        ApiResponse<bool> Remove(int id);
        ApiResponse<bool> Update(TRequest entity, int id);
    }
}
