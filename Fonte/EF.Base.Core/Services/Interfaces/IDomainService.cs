using Base.Core.Entities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EF.Base.Core.Services.Interfaces
{
    public interface IDomainService<TDto, TEntity, TPrimaryKey> where TDto : class where TEntity : class, IEntity<TPrimaryKey>
    {
        Task<TResponse> Add<TResponse>(TDto dto) where TResponse : class;
        Task<TResponse> Update<TResponse>(TDto dto, TPrimaryKey key) where TResponse : class;
        Task<bool> Delete(TPrimaryKey key);
        TDto GetById(TPrimaryKey id);
        IList<TDto> GetAll();
        void Dispose();
    }
}