using Sipay_Cohort_MovieStore.Business.Services.Generic;
using Sipay_Cohort_MovieStore.Dtos.Director;
using DirectorModel = Sipay_Cohort_MovieStore.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sipay_Cohort_MovieStore.DataAccess.UnitOfWork;
using AutoMapper;
using FluentValidation;

namespace Sipay_Cohort_MovieStore.Business.Services.Director
{
    public class DirectorService : GenericService<DirectorModel.Director, DirectorRequest, DirectorResponse>, IDirectorService
    {
        public DirectorService(IUow uow, IMapper mapper,IValidator<DirectorRequest> validator) : base(uow, mapper, validator)
        {
        }
    }
}
