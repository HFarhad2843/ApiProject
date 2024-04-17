using BlankSolution.Core.Entities;

namespace BlankSolution.Data.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
    }
}