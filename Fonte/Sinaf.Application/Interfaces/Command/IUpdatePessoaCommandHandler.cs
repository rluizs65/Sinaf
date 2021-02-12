using Sinaf.DTO.Requests;

namespace Sinaf.Application.Interfaces.Command
{
    public interface IUpdatePessoaCommandHandler
    {
        bool UpdatePessoa(UpdatePessoaRequestDTO request);
    }
}
