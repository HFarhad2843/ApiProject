using BlankSolution.Core.Entities;
using BlankSolution.Core.Repositories;
using BlankSolution.Data.Contexts;
using System.Linq.Expressions;

namespace BlankSolution.Data.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext context) : base(context)
        {
        }

        public void Delete(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAllAsync(Expression<Func<Movie, bool>> expression = null, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetAsync(Expression<Func<Movie, bool>> expression = null, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        Task<Movie> IMovieRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
