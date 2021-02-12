using Base.Core.Paging;
using Sinaf.DTO.Responses;
using Sinaf.DTO.Requests;

namespace Sinaf.Application.Interfaces.Query
{
    public interface IGetAllClienteQueryHandler
    {
        Page<GetClienteResponseDTO> GetAllCliente(GetAllClientRequestDTO request);
    }
}
