using BlankSolution.Core.Entities;

namespace BlankSolution.Business.Services.Interfaces
{
   public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllAsync();
        Task CreateAsync(Genre genre);
        Task<IEnumerable<Genre>> GetAllPaginated(int page = 1,int pageSize = 2);
    }
}
