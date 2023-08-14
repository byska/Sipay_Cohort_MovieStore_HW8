using Sipay_Cohort_MovieStore.Business.Services.Generic;
using Sipay_Cohort_MovieStore.Core.Entities.Interfaces;
using Sipay_Cohort_MovieStore.Core.Utilities.Response;
using Sipay_Cohort_MovieStore.Dtos.Purchased;
using System.Linq.Expressions;
using PurchasedModel = Sipay_Cohort_MovieStore.Entities.DbSets;

namespace Sipay_Cohort_MovieStore.Business.Services.Purchased
{
    public interface IPurchasedService : IGenericService<PurchasedModel.Purchased, PurchasedRequest, PurchasedResponse>
    {
       
    }
}
