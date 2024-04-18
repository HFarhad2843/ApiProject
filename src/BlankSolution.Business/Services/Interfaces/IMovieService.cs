using BlankSolution.Business.DTOs.MovieDTOs;
using BlankSolution.Core.Entities;

namespace BlankSolution.Business.Services.Interfaces
{
    public interface IMovieService
    {
        Task CreateAsync(MovieCreateDto dto);
        Task<IEnumerable<Movie>> GetAllAsync();
    }
}
