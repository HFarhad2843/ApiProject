﻿using BlankSolution.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlankSolution.Core.Repositories
{
    public interface IGenericRepository<IEntity>
        where IEntity : BaseEntity, new()
    {
        DbSet<IEntity> Table { get; }
        Task InsertAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null, params string[] includes);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null, params string[] includes);
        Task<TEntity> GetByIdAsync(int id);
        void Delete(TEntity entity);
        Task<int> CommitAsync();
    }
}
