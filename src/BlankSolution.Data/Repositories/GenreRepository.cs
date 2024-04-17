using BlankSolution.Core.Entities;
using BlankSolution.Core.Repositories;
using BlankSolution.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlankSolution.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<Genre> Table { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Delete(Genre genre)
        {
            _context.Genres.Remove(genre);
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Genre>> GetAllAsync(Expression<Func<Genre, bool>> expression = null, params string[] includes)
        {
            var query = _context.Genres.AsQueryable();
            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return expression is not null
                ? await query.Where(expression).ToListAsync()
                : await query.ToListAsync();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public async Task<Genre> GetAsync(Expression<Func<Genre, bool>> expression = null, params string[] includes)
        {
            var query = _context.Genres.AsQueryable();
            if(includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return expression is not null 
                ? await query.Where(expression).FirstOrDefaultAsync() 
                : await query.FirstOrDefaultAsync();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task InsertAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
        }

        public Task InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> Core.Repositories.IGenericRepository<Genre>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
