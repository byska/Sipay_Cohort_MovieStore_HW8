using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sipay_Cohort_MovieStore.Business.Services.Token;
using Sipay_Cohort_MovieStore.Core.Utilities.Response;
using Sipay_Cohort_MovieStore.Dtos.Token;
using Sipay_Cohort_MovieStorel.Dtos.Token;

namespace Sipay_Cohort_MovieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService service;
        public TokenController(ITokenService service)
        {
            this.service = service;
        }

        [HttpPost("Login")]
        public async Task<ApiResponse<TokenResponse>> Post([FromBody] TokenRequest request)
        {
            var response = await service.Login(request);
            return response;
        }
    }
}
