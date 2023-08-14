using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sipay_Cohort_MovieStore.Business.Services.Movie;
using Sipay_Cohort_MovieStore.Core.Utilities.Response;
using Sipay_Cohort_MovieStore.Dtos.Movie;

namespace Sipay_Cohort_MovieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public async Task<ApiResponse<List<MovieResponse>>> GetAll()
        {
            var response =await _movieService.GetActive();
            return response;
        }
        [HttpPost]
        public async Task<ApiResponse<bool>> Create([FromBody]MovieRequest request)
        {
            var response=await _movieService.Add(request);
            return response;
        }
        [HttpDelete("{id}")]
        public ApiResponse<bool> Delete(int id)
        {
            var response = _movieService.Remove(id);
            return response;
        }
        [HttpPut("{id}")]
        public ApiResponse<bool> Update(int id, [FromBody]MovieRequest request)
        {
            var response = _movieService.Update(request, id);
            return response;
        }
    }
}
