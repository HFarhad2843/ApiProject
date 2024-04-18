using BlankSolution.Business.CustomExceptions.CommonExceptions;
using BlankSolution.Business.DTOs.MovieDTOs;
using BlankSolution.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlankSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService movieService;
         public MoviesController(IMovieService movieService)
         {
            this.movieService = movieService;
         }
        [HttpGet("")]
        public async Task<IActionResult> Create(MovieCreateDto createDto)
        {
            try
            {
                await movieService.CreateAsync(createDto);
            }
            catch(NotFoundException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch
            {
                throw;
            }
            return Created();
        }
    }
}
