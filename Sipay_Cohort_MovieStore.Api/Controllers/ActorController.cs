using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sipay_Cohort_MovieStore.Business.Services.Actor;
using Sipay_Cohort_MovieStore.Business.Services.Movie;
using Sipay_Cohort_MovieStore.Core.Utilities.Response;
using Sipay_Cohort_MovieStore.Dtos.Actor;
using Sipay_Cohort_MovieStore.Dtos.Movie;

namespace Sipay_Cohort_MovieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }
        [HttpGet]
        public async Task<ApiResponse<List<ActorResponse>>> GetAll()
        {
            var response = await _actorService.GetActive();
            return response;
        }
        [HttpPost]
        public async Task<ApiResponse<bool>> Create([FromBody] ActorRequest request)
        {
            var response = await _actorService.Add(request);
            return response;
        }
        [HttpDelete("{id}")]
        public ApiResponse<bool> Delete(int id)
        {
            var response = _actorService.Remove(id);
            return response;
        }
        [HttpPut("{id}")]
        public ApiResponse<bool> Update(int id, [FromBody] ActorRequest request)
        {
            var response = _actorService.Update(request, id);
            return response;
        }
    }
}
