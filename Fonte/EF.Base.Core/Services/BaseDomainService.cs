using AutoMapper;
using Base.Core.Entities.Interfaces;
using EF.Base.Core.Repositories;
using EF.Base.Core.Services.Interfaces;
using EF.Base.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF.Base.Core.Services
{
    /// <summary>
    /// Base do serviço de domínio com entidade e chave PK
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class BaseDomainService<TDto, TEntity, TPrimaryKey> : IDisposable, IDomainService<TDto, TEntity, TPrimaryKey>
        where TDto : class  where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IRepository<TEntity, TPrimaryKey> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BaseDomainService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<TEntity, TPrimaryKey> repository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TResponse> Add<TResponse>(TDto dto) where TResponse : class
        {
            _unitOfWork.BeginTransaction();

            try
            {
                TEntity entity = _mapper.Map<TDto, TEntity>(dto);
                var result = await _repository.Add(entity);
                _unitOfWork.Commit();

                return _mapper.Map<TEntity, TResponse>(result);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw ex;
            }
        }

        public async Task<TResponse> Update<TResponse>(TDto dto, TPrimaryKey key) where TResponse : class
        {
            _unitOfWork.BeginTransaction();

            try
            {
                TEntity entity = _mapper.Map<TDto, TEntity>(dto);
                var result = await _repository.Update(entity, key);
                _unitOfWork.Commit();

                return _mapper.Map<TEntity, TResponse>(result);
            }
            catch(Exception ex)
            {
                _unitOfWork.RollBack();
                throw ex;
            }
        }

        public async Task<bool> Delete(TPrimaryKey key)
        {
            _unitOfWork.BeginTransaction();

            try
            {
                bool result = await _repository.Delete(key);
                _unitOfWork.Commit();
                return result;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw ex;
            }
        }

        public TDto GetById(TPrimaryKey id)
        {
            TEntity entity = _repository.GetById(id);
            TDto dto = _mapper.Map<TEntity, TDto>(entity);
            return dto;
        }

        public IList<TDto> GetAll()
        {
            IList<TEntity> entity = _repository.GetAll().ToList();
            IList<TDto> dto = _mapper.Map<IList<TEntity>, IList<TDto>>(entity);
            return dto;
        }

        public void Dispose()
        {
        }
    }
}
