using BlankSolution.Core.Entities;
using BlankSolution.Core.Repositories;
using BlankSolution.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlankSolution.Data.Repositories
{
    public class GenericRepository<IEntity> : IGenericRepository<IEntity> where IEntity : BaseEntity, new()

    {
        private readonly AppDbContext context;
        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }

        public DbSet<IEntity> Table => context.Set<IEntity>();

        public bool AnyGenreName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Delete(IEntity entity)
        {
            Table.Remove(entity);
        }


        public async Task<IEnumerable<IEntity>> GetAllAsync(Expression<Func<IEntity, bool>> expression = null, params string[] includes)
        {
            var query = Table.AsQueryable();
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

        public async Task<IEntity> GetAsync(Expression<Func<IEntity, bool>> expression = null, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (includes is not null)
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

        public async Task<IEntity> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task InsertAsync(IEntity entity)
        {
            await Table.AddAsync(entity);
        }
    }
}
