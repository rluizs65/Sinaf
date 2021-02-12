using Sinaf.DTO.Requests;

namespace Sinaf.Application.Interfaces.Command
{
    public interface IDeletePessoaCommandHandler
    {
        long DeletePessoa(DeletePessoaRequestDTO request);
    }
}
