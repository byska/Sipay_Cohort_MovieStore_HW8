using Sipay_Cohort_MovieStore.Business.Services.Generic;
using Sipay_Cohort_MovieStore.Dtos.Movie;
using CustomerModel= Sipay_Cohort_MovieStore.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sipay_Cohort_MovieStore.Dtos.Customer;

namespace Sipay_Cohort_MovieStore.Business.Services.Customer
{
    public interface ICustomerService : IGenericService<CustomerModel.Customer, CustomerRequest, CustomerResponse>
    {
    }
}
