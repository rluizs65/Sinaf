using AutoMapper;
using EF.Base.Core.Services;
using EF.Base.Core.UnitOfWork;
using Sinaf.Domain.Data.Entities;
using Sinaf.Domain.Data.Repositories.Interfaces;
using Sinaf.Domain.Interfaces.Command;
using Sinaf.DTO.Requests;

namespace Sinaf.Domain.Services.Command
{
    public class DeletePessoaCommandService : BaseDomainService<DeletePessoaRequestDTO, PessoaEntity, long> , IDeletePessoaCommandService    
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPessoaRepository _repository;

        public DeletePessoaCommandService(IUnitOfWork unitOfWork, IMapper mapper, IPessoaRepository repository) : 
            base(unitOfWork, mapper, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }
    }
}
