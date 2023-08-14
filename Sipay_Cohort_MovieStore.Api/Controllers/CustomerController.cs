using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sipay_Cohort_MovieStore.Business.Services.Customer;
using Sipay_Cohort_MovieStore.Core.Utilities.Response;
using Sipay_Cohort_MovieStore.Dtos.Customer;
using Sipay_Cohort_MovieStore.Dtos.Movie;

namespace Sipay_Cohort_MovieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
           _customerService = customerService;
        }
        [HttpPost]
        public async Task<ApiResponse<bool>> Create([FromBody] CustomerRequest request)
        {
            var response = await _customerService.Add(request);
            return response;
        }
        [HttpDelete("{id}")]
        public ApiResponse<bool> Delete(int id)
        {
            var response = _customerService.Remove(id);
            return response;
        }
    }
}
