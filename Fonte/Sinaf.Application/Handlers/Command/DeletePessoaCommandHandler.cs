using Base.Core.Enumerators;
using Base.Core.Extensions;
using Base.Core.Handlers;
using Base.Core.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using Sinaf.Application.Validators;
using Sinaf.Domain.Interfaces.Command;
using Sinaf.DTO.Requests;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sinaf.Application.Handlers.Command
{
    public class DeletePessoaCommandHandler : BaseHandler<DeletePessoaCommandHandler>,
        IRequestHandler<DeletePessoaRequestDTO, Result>
    {
        private readonly IAddPessoaCommandService _service;

        public DeletePessoaCommandHandler(IAddPessoaCommandService service,
            ILogger<DeletePessoaCommandHandler> logger) : base(logger)
        {
            _service = service;
        }

        public async Task<Result> Handle(DeletePessoaRequestDTO request, CancellationToken cancellationToken)
        {
            try
            {
                //Faz a validação dos parâmetros de entrada
                DeletePessoaCommandValidator validator = new DeletePessoaCommandValidator();
                var validate = validator.Validate(request);

                if (validate.IsValid)
                {
                    ActionResult.IsValid = await _service.Delete(request.IdPessoa);

                    if (!ActionResult.IsValid)
                    {
                        ActionResult.Errors = new Error()
                        {
                            Code = ErrorCode.ERROR_RECORD_NOT_FOUND.GetCode(),
                            Message = ErrorCode.ERROR_RECORD_NOT_FOUND.GetAttributeDescription()
                        };
                    }
                }
                else
                    return GenerateModelError(ActionResult, validate.Errors);
            }
            catch (Exception ex)
            {
                ActionResult.Errors = new Error()
                {
                    Code = ErrorCode.EXCEPTION_ERROR.GetCode(),
                    Message = ex.InnerException.Message
                };
            }

            return await Task.FromResult(ActionResult);
        }
    }

}
