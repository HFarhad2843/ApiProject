using BlankSolution.Business.Services.Implementations;
using BlankSolution.Business.Services.Interfaces;
using BlankSolution.Core.Entities;
using BlankSolution.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlankSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _genreService.GetAllAsync());
        }
        [HttpGet("[action]")]
        public async Task <IActionResult> GetAllPaginated(int page = 1, int pageSize = 2) 
        {
            return Ok(await _genreService.GetAllPaginated(page));
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateAsync(Genre genre)
        {
            await _genreService.CreateAsync(genre);
            return Ok();
        }
    }
}
