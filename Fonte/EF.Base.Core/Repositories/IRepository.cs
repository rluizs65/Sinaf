using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Base.Core.Entities.Interfaces;

namespace EF.Base.Core.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity, TPrimaryKey key);
        Task<bool> Delete(TPrimaryKey key);
        TEntity Get(Expression<Func<TEntity, bool>> match);
        TEntity GetById(TPrimaryKey id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        int Count();
        Task<int> CountAsync(); 
        void Dispose();
    }
}
