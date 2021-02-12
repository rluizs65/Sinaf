using Base.Core.Enumerators;
using Base.Core.Extensions;
using Base.Core.Handlers;
using Base.Core.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using Sinaf.Application.Validators;
using Sinaf.Domain.Interfaces.Command;
using Sinaf.DTO.Requests;
using Sinaf.DTO.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sinaf.Application.Handlers.Command
{
    public class UpdatePessoaCommandHandler : BaseHandler<UpdatePessoaCommandHandler, PessoaResponseDTO>, 
        IRequestHandler<UpdatePessoaRequestDTO, Result<PessoaResponseDTO>>
    {
        private readonly IUpdatePessoaCommandService _service;

        public UpdatePessoaCommandHandler(IUpdatePessoaCommandService service,
            ILogger<UpdatePessoaCommandHandler> logger) : base(logger)
        {
            _service = service;
        }

        public async Task<Result<PessoaResponseDTO>> Handle(UpdatePessoaRequestDTO request, CancellationToken cancellationToken)
        {
            try
            {
                //Faz a validação dos parâmetros de entrada
                UpdatePessoaCommandValidator validator = new UpdatePessoaCommandValidator();
                var validate = validator.Validate(request);

                if (validate.IsValid)
                {
                    ActionResult.Response = await _service.Update<PessoaResponseDTO>(request, request.IdPessoa);
                    ActionResult.IsValid = true;
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
