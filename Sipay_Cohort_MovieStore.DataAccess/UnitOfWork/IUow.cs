using Sipay_Cohort_MovieStore.Core.Entities.Interfaces;
using Sipay_Cohort_MovieStore.DataAccess.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.DataAccess.UnitOfWork
{
    public interface IUow
    {
        void Complete();
        void CompleteWithTransaction();
        IGenericRepository<T> GetRepository<T>() where T : class, IEntity;
    }
}
