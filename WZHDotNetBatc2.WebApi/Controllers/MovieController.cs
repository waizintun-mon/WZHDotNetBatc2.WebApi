using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WZHDotNetBatc2.Database.AppDbContextModels;
using WZHDotNetBatc2.WebApi.BL;
using WZHDotNetBatc2.WebApi.Model;


namespace WZHDotNetBatc2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet("{PageNo}/{PageSize}")]
        public async Task<IActionResult> GetMovies(int PageNo, int PageSize)
        {
            var lst = await _movieService.GetMovies(PageNo, PageSize);
            return Ok(lst);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(TblMovie movieModel)
        {
            if (movieModel == null)
            {
                return BadRequest("product cannot be null");
            }
            var newMovie = await _movieService.CreateMovie(movieModel);
            return Ok(newMovie);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateMovieAsync(int id, TblMovie movieModel)
        {
            if (id == 0)
            {
                return BadRequest("No movie ");

            }
            movieModel.MovieId = id;
            var result = await _movieService.UpdadeMovie(movieModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            {
                if (id == 0)
                {
                    return BadRequest("invalid id");
                }
                var result =await _movieService.DeleteMovie(id);
                return Ok(result);
            }
        }
    }
}
