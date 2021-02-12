using Sinaf.DTO.Responses;
using Sinaf.DTO.Requests;

namespace Sinaf.Application.Interfaces.Query
{
    public interface IGetClienteByNomeENascimentoQueryHandler
    {
        GetClienteResponseDTO GetClienteByNome(GetClientByNomeRequestDTO request);
    }
}
