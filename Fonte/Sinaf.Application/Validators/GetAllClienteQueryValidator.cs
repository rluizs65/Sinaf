using FluentValidation;
using Sinaf.DTO.Requests;

namespace Sinaf.Application.Validators
{
    public class GetAllClienteQueryValidator : AbstractValidator<GetAllClientRequestDTO>
    {
        public GetAllClienteQueryValidator()
        {
            RuleFor(x => x.PageCount).NotNull().NotEmpty();
            RuleFor(x => x.PageSize).NotNull().NotEmpty();
        }
    }
}