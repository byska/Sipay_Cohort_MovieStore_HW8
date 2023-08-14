using AutoMapper;
using FluentValidation;
using Sipay_Cohort_MovieStore.Business.Services.Generic;
using Sipay_Cohort_MovieStore.DataAccess.UnitOfWork;
using Sipay_Cohort_MovieStore.Dtos.Customer;
using CustomerModel = Sipay_Cohort_MovieStore.Entities.DbSets;

namespace Sipay_Cohort_MovieStore.Business.Services.Customer
{
    public class CustomerService : GenericService<CustomerModel.Customer, CustomerRequest, CustomerResponse>, ICustomerService
    {
        public CustomerService(IUow uow, IMapper mapper,IValidator<CustomerRequest> validator) : base(uow, mapper, validator)
        {
        }
    }
}
