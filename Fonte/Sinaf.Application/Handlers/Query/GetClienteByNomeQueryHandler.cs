using MediatR;
using Sinaf.DTO.Responses;
using Sinaf.DTO.Requests;
using System.Threading;
using System.Threading.Tasks;
using Sinaf.Domain.Interfaces.Query;
using Base.Core.Handlers;
using Microsoft.Extensions.Logging;
using Sinaf.Application.Validators;
using System;
using Base.Core.Results;
using Base.Core.Enumerators;
using Base.Core.Extensions;

namespace Sinaf.Application.Handlers.Query
{
    public class GetClienteByNomeQueryHandler : BaseHandler<GetClienteByNomeQueryHandler, GetClienteResponseDTO>, 
        IRequestHandler<GetClientByNomeRequestDTO, Result<GetClienteResponseDTO>>
    {
        private readonly IClienteQueryService _service;

        public GetClienteByNomeQueryHandler(IClienteQueryService service,
            ILogger<GetClienteByNomeQueryHandler> logger) : base(logger)
        {
            _service = service;
        }

        public async Task<Result<GetClienteResponseDTO>> Handle(GetClientByNomeRequestDTO request, 
            CancellationToken cancellationToken)
        {
            try
            {
                //Faz a validação dos parâmetros de entrada
                GetClienteByNomeQueryValidator validator = new GetClienteByNomeQueryValidator();
                var validate = validator.Validate(request);

                if (validate.IsValid)
                {
                    ActionResult.Response = _service.GetByNome(request.Nome);
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
