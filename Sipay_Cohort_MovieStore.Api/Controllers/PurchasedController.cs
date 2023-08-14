using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sipay_Cohort_MovieStore.Business.Services.Purchased;
using Sipay_Cohort_MovieStore.Core.Utilities.Response;
using Sipay_Cohort_MovieStore.Dtos.Purchased;
using System.Security.Claims;

namespace Sipay_Cohort_MovieStore.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasedController : ControllerBase
    {
        private readonly IPurchasedService _purchasedService;
        public PurchasedController(IPurchasedService purchasedService)
        {
            _purchasedService = purchasedService;
        }
        [HttpGet]
        public async Task<ApiResponse<List<PurchasedResponse>>> GetAllByUserId()
        {
            var userid = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
            var id = Convert.ToInt32(userid);
            var response =await _purchasedService.GetAllWithParameters(x=>x.IsActive==true,x=>x.CustomerId==id);
            return response;
        }
        [HttpPost]
        public async Task<ApiResponse<bool>> Create([FromBody]PurchasedRequest request)
        {
            var userid = (User.Identity as ClaimsIdentity).FindFirst("Id")?.Value;
            var id = Convert.ToInt32(userid);
            request.CustomerId = id;
            var response =await _purchasedService.Add(request);
            return response;
        }
    }
}
