using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sipay_Cohort_MovieStore.Business.Services.Director;
using Sipay_Cohort_MovieStore.Business.Services.Movie;
using Sipay_Cohort_MovieStore.Core.Utilities.Response;
using Sipay_Cohort_MovieStore.Dtos.Director;
using Sipay_Cohort_MovieStore.Dtos.Movie;

namespace Sipay_Cohort_MovieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorService;
        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }
        [HttpGet]
        public async Task<ApiResponse<List<DirectorResponse>>> GetAll()
        {
            ApiResponse<List<DirectorResponse>>? response = await _directorService.GetActive();
            return response;
        }
        [HttpPost]
        public async Task<ApiResponse<bool>> Create([FromBody] DirectorRequest request)
        {
            var response = await _directorService.Add(request);
            return response;
        }
        [HttpDelete("{id}")]
        public ApiResponse<bool> Delete(int id)
        {
            var response = _directorService.Remove(id);
            return response;
        }
        [HttpPut("{id}")]
        public ApiResponse<bool> Update(int id, [FromBody] DirectorRequest request)
        {
            var response = _directorService.Update(request, id);
            return response;
        }
    }
}
