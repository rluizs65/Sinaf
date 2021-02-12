using FluentValidation;
using Sinaf.DTO.Requests;

namespace Sinaf.Application.Validators
{
    public class GetClienteByNomeQueryValidator : AbstractValidator<GetClientByNomeRequestDTO>
    {
        public GetClienteByNomeQueryValidator()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty();        }
    }
}