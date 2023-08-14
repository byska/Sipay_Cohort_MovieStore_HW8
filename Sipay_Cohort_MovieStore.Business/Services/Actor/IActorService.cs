using Sipay_Cohort_MovieStore.Business.Services.Generic;
using Sipay_Cohort_MovieStore.Dtos.Customer;
using ActorModel= Sipay_Cohort_MovieStore.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sipay_Cohort_MovieStore.Dtos.Actor;

namespace Sipay_Cohort_MovieStore.Business.Services.Actor
{
    public interface IActorService : IGenericService<ActorModel.Actor, ActorRequest, ActorResponse>
    {
    }
}
