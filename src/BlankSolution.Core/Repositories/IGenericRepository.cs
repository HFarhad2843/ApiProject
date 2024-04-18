using BlankSolution.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlankSolution.Core.Repositories
{
    public interface IGenericRepository<IEntity>
        where IEntity : BaseEntity, new()
    {
        DbSet<IEntity> Table { get; }
        Task InsertAsync(IEntity entity);
        Task<IEnumerable<IEntity>> GetAllAsync(Expression<Func<IEntity, bool>> expression = null, params string[] includes);
        Task<IEntity> GetAsync(Expression<Func<IEntity, bool>> expression = null, params string[] includes);
        Task<IEntity> GetByIdAsync(int id);
        void Delete(IEntity entity);
        Task<int> CommitAsync();
    }
}
