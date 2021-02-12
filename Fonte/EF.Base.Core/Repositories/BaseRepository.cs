using Base.Core.Entities.Interfaces;
using EF.Base.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EF.Base.Core.Repositories
{
    public class BaseRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> 
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
           _unitOfWork.Context.Set<TEntity>().Add(entity);
            return await Task.Run(() => entity);
        }

        public virtual async Task<TEntity> Update(TEntity entity, TPrimaryKey key)
        {
            if (entity == null) return null;

            TEntity result = _unitOfWork.Context.Set<TEntity>().Find(key);
            if (result != null)
            {
                _unitOfWork.Context.Entry(result).CurrentValues.SetValues(entity);
            }
            return await Task.Run(() => result);
        }

        public virtual async Task<bool> Delete(TPrimaryKey key)
        {
            var entity = _unitOfWork.Context.Set<TEntity>().Find(key);

            if (entity != null)
            {
                await Task.Run(() => _unitOfWork.Context.Set<TEntity>().Remove(entity));
                return true;
            }
            return false;
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> match)
        {
            return _unitOfWork.Context.Set<TEntity>().SingleOrDefault(match);
        }

        public virtual TEntity GetById(TPrimaryKey id)
        {
            return _unitOfWork.Context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _unitOfWork.Context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Context.Set<TEntity>().Where(predicate);
        }

        public int Count()
        {
            return _unitOfWork.Context.Set<TEntity>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.Context.Set<TEntity>().CountAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}