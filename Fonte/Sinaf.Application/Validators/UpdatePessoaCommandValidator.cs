using Base.Core.Enumerators;
using Base.Core.Extensions;
using Base.Core.Util;
using FluentValidation;
using Sinaf.DTO.Requests;

namespace Sinaf.Application.Validators
{
    public class UpdatePessoaCommandValidator : AbstractValidator<UpdatePessoaRequestDTO>
    {
        public UpdatePessoaCommandValidator()
        {
            RuleFor(x => x.Cpf).NotNull().NotEmpty()
                .WithErrorCode(ErrorCode.ERROR_INVALID_CPF.GetCode())
                .WithMessage(ErrorCode.ERROR_INVALID_CPF.GetAttributeDescription());

            RuleFor(x => x.Cpf).Must(CPF.IsValid)
                .WithErrorCode(ErrorCode.ERROR_DOCUMENT_NOT_FOUND.GetCode())
                .WithMessage(ErrorCode.ERROR_DOCUMENT_NOT_FOUND.GetAttributeDescription());

            RuleFor(x => x.IdPessoa).NotNull().NotEmpty();
            RuleFor(x => x.DataNascimento).NotNull().NotEmpty();
            RuleFor(x => x.Sexo).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();
        }
    }
}