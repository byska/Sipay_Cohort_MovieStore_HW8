using Serilog;
using Sipay_Cohort_MovieStore.DataAccess.Context;
using Sipay_Cohort_MovieStore.DataAccess.DataAccess.Abstract;
using Sipay_Cohort_MovieStore.DataAccess.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly MovieStoreDbContext _dbContext;
        public Uow(MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Complete()
        {
            _dbContext.SaveChanges();
        }

        public void CompleteWithTransaction()
        {
            using (var dbTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.SaveChanges();
                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    Log.Error(ex, "CompleteWithTransaction");
                }
            }
        }

        IGenericRepository<T> IUow.GetRepository<T>()
        {
            return new GenericRepository<T>(_dbContext);
        }
    }
}
