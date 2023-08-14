using AutoMapper;
using FluentValidation;
using Sipay_Cohort_MovieStore.Business.Services.Generic;
using Sipay_Cohort_MovieStore.DataAccess.UnitOfWork;
using Sipay_Cohort_MovieStore.Dtos.Purchased;
using PurchasedModel = Sipay_Cohort_MovieStore.Entities.DbSets;

namespace Sipay_Cohort_MovieStore.Business.Services.Purchased
{
    public class PurchasedService : GenericService<PurchasedModel.Purchased, PurchasedRequest, PurchasedResponse>, IPurchasedService
    {
        public PurchasedService(IUow uow, IMapper mapper, IValidator<PurchasedRequest> validator) : base(uow, mapper, validator)
        {
        }

    }
}
