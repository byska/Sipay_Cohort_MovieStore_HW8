using Sipay_Cohort_MovieStore.Business.Services.Generic;
using Sipay_Cohort_MovieStore.Dtos.Actor;
using ActorModel = Sipay_Cohort_MovieStore.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Sipay_Cohort_MovieStore.DataAccess.UnitOfWork;

namespace Sipay_Cohort_MovieStore.Business.Services.Actor
{
    public class ActorService : GenericService<ActorModel.Actor, ActorRequest, ActorResponse>,IActorService
    {
        public ActorService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
