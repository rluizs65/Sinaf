using Sinaf.DTO.Requests;

namespace Sinaf.Application.Interfaces.Command
{
    public interface IAddPessoaCommandHandler
    {
        long AddPessoa(AddPessoaRequestDTO request);
    }
}
