using BlankSolution.Core.Entities;

namespace BlankSolution.Business.Services.Interfaces
{
   public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllAsync();
        Task CreateAsync(Genre genre);
    }
}
