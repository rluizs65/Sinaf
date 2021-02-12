using Base.Core.Results;
using MediatR;

namespace Sinaf.DTO.Requests
{
    public class DeletePessoaRequestDTO : IRequest<Result>
    {
        public virtual long IdPessoa { get; set; }
    }
}
