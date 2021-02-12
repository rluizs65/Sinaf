using EF.Base.Core.Services.Interfaces;
using Sinaf.Domain.Data.Entities;
using Sinaf.DTO.Requests;

namespace Sinaf.Domain.Interfaces.Command
{
    public interface IDeletePessoaCommandService : IDomainService<DeletePessoaRequestDTO, PessoaEntity, long>
    {
    }
}
