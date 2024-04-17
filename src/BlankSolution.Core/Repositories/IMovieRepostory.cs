using BlankSolution.Core.Entities;
using System.Linq.Expressions;

namespace BlankSolution.Core.Repositories
{
    public interface IMovieRepostory
    {
        Task InsertAsync(Movie movie);
        Task<IEnumerable<Movie>> GetAllAsync(Expression<Func<Movie, bool>> expression = null, params string[] includes);
        Task<Movie> GetAsync(Expression<Func<Movie, bool>> expression = null, params string[] includes);
        Task<Movie> GetByIdAsync(int id);
        void Delete(Movie movie);
        Task<int> CommitAsync();
    }
}
