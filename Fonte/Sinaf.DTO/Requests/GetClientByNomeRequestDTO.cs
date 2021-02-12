using Base.Core.Results;
using MediatR;
using Sinaf.DTO.Responses;

namespace Sinaf.DTO.Requests
{
    public class GetClientByNomeRequestDTO : IRequest<Result<GetClienteResponseDTO>>
    {
        public string Nome { get; set; }
    }
}
