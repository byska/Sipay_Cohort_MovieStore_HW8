using AutoMapper;
using Sipay_Cohort_MovieStore.Core.Entities.BaseEntities;
using Sipay_Cohort_MovieStore.Core.Utilities.Response;
using Sipay_Cohort_MovieStore.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Business.Services.Generic
{
    public class GenericService<TEntity, TRequest, TResponse> : IGenericService<TEntity, TRequest, TResponse> where TEntity : BaseEntity
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public GenericService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public virtual async Task<ApiResponse<bool>> Activate(int id)
        {
            if (id == 0 || _uow.GetRepository<TEntity>().GetByID(id) == null)
                return new ApiResponse<bool>(false);
            else
                return new ApiResponse<bool>(await _uow.GetRepository<TEntity>().Activate(id));
        }

        public virtual async Task<ApiResponse<bool>> Add(TRequest request)
        {
            var entity = _mapper.Map<TRequest, TEntity>(request);
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = "admin";

            var result = await _uow.GetRepository<TEntity>().Add(entity);
            _uow.Complete();
            return new ApiResponse<bool>(result);
        }

        public virtual ApiResponse<TResponse> GetById(int id)
        {
            var result = _uow.GetRepository<TEntity>().GetByID(id);
            var response = _mapper.Map<TResponse>(result);
            return new ApiResponse<TResponse>(response);
        }

        public virtual async Task<ApiResponse<List<TResponse>>> GetActive()
        {
            List<TEntity> entities = await _uow.GetRepository<TEntity>().GetActive();
            List<TResponse> responses = _mapper.Map<List<TEntity>, List<TResponse>>(entities);
            return new ApiResponse<List<TResponse>>(responses);
        }

        public virtual ApiResponse<bool> Remove(TEntity entity)
        {
            var result = _uow.GetRepository<TEntity>().Remove(entity);
            _uow.Complete();
            return new ApiResponse<bool>(result);
        }

        public virtual ApiResponse<bool> Remove(int id)
        {
            TEntity entities = _uow.GetRepository<TEntity>().GetByID(id);
            var result = _uow.GetRepository<TEntity>().Remove(entities);
            _uow.Complete();
            return new ApiResponse<bool>(result);
        }

        public virtual ApiResponse<bool> Update(TRequest entity, int id)
        {

            var user = _uow.GetRepository<TEntity>().GetByID(id);
            if (user == null)
            {
                return new ApiResponse<bool>("Record not found!");
            }

            var update = _mapper.Map<TRequest, TEntity>(entity);
            update.CreatedBy = "admin";
            var result = _uow.GetRepository<TEntity>().Update(update);
            _uow.Complete();
            return new ApiResponse<bool>(result);
        }
    }
}
