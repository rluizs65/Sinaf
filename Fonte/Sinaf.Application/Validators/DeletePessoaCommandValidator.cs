using FluentValidation;
using Sinaf.DTO.Requests;

namespace Sinaf.Application.Validators
{
    public class DeletePessoaCommandValidator : AbstractValidator<DeletePessoaRequestDTO>
    {
        public DeletePessoaCommandValidator()
        {
            RuleFor(x => x.IdPessoa).NotNull().NotEmpty();
        }
    }
}