using AutoMapper;
using EF.Base.Core.Services;
using Sinaf.Domain.Data.Entities;
using Sinaf.Domain.Data.Repositories.Interfaces;
using System;
using Sinaf.DTO.Responses;
using Sinaf.Domain.Interfaces.Query;
using EF.Base.Core.UnitOfWork;

namespace Sinaf.Domain.Services.Query
{
    public class ClienteQueryService : BaseDomainService<GetClienteResponseDTO, ClienteEntity, long>, IClienteQueryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _repository;

        public ClienteQueryService(IUnitOfWork unitOfWork, IMapper mapper, IClienteRepository repository) :
            base(unitOfWork, mapper, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public GetClienteResponseDTO GetByNome(string nome)
        {
            try
            {
                var entity = _repository.GetByNome(nome);
                var result = _mapper.Map<ClienteEntity, GetClienteResponseDTO>(entity);
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
