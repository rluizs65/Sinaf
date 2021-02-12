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
    public class AddPessoaCommandHandler : BaseHandler<AddPessoaCommandHandler, PessoaResponseDTO>, 
        IRequestHandler<AddPessoaRequestDTO, Result<PessoaResponseDTO>>
    {
        private readonly IAddPessoaCommandService _service;

        public AddPessoaCommandHandler(IAddPessoaCommandService service, 
            ILogger<AddPessoaCommandHandler> logger) : base(logger)
        {
            _service = service;
        }

        public async Task<Result<PessoaResponseDTO>> Handle(AddPessoaRequestDTO request, CancellationToken cancellationToken)
        {
            try
            {
                //Faz a validação dos parâmetros de entrada
                AddPessoaCommandValidator validator = new AddPessoaCommandValidator();
                var validate = validator.Validate(request);

                if (validate.IsValid)
                {
                    ActionResult.Response = await _service.Add<PessoaResponseDTO>(request);
                    ActionResult.IsValid = true;
                }
                else
                    return GenerateModelError(ActionResult, validate.Errors);
            }
            catch(Exception ex)
            {
                ActionResult.Errors = new Error() { 
                    Code = ErrorCode.EXCEPTION_ERROR.GetCode(), 
                    Message = ex.InnerException.Message
                };
            }

            return await Task.FromResult(ActionResult);
        }
    }
}
