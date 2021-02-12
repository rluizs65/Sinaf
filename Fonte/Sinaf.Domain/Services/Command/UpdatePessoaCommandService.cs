using AutoMapper;
using EF.Base.Core.Services;
using EF.Base.Core.UnitOfWork;
using Sinaf.Domain.Data.Entities;
using Sinaf.Domain.Data.Repositories.Interfaces;
using Sinaf.Domain.Interfaces.Command;
using Sinaf.DTO.Requests;

namespace Sinaf.Domain.Services.Command
{
    public class UpdatePessoaCommandService : BaseDomainService<UpdatePessoaRequestDTO, PessoaEntity, long>, IUpdatePessoaCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPessoaRepository _repository;

        public UpdatePessoaCommandService(IUnitOfWork unitOfWork, IMapper mapper, IPessoaRepository repository) :
            base(unitOfWork, mapper, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }
    }
}
