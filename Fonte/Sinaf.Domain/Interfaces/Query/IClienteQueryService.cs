using EF.Base.Core.Services.Interfaces;
using Sinaf.Domain.Data.Entities;
using Sinaf.DTO.Responses;

namespace Sinaf.Domain.Interfaces.Query
{
    public interface IClienteQueryService : IDomainService<GetClienteResponseDTO, ClienteEntity, long>
    {
        GetClienteResponseDTO GetByNome(string nome);
    }
}
