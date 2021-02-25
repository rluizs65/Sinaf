using MediatR;
using Sinaf.DTO.Responses;
using Sinaf.DTO.Requests;
using System.Threading;
using System.Threading.Tasks;
using Sinaf.Domain.Interfaces.Query;
using Base.Core.Handlers;
using Microsoft.Extensions.Logging;
using Sinaf.Application.Validators;
using Base.Core.Results;
using System;
using Base.Core.Enumerators;
using Base.Core.Extensions;

namespace Sinaf.Application.Handlers.Query
{
    public class GetAllClienteQueryHandler : BasePagingHandler<GetAllClienteQueryHandler, GetClienteResponseDTO>, 
        IRequestHandler<GetAllClientRequestDTO, ResultPaging<GetClienteResponseDTO>>
    {
        private readonly IClienteQueryService _service;

        public GetAllClienteQueryHandler(IClienteQueryService service,
            ILogger<GetAllClienteQueryHandler> logger) : base(logger)
        {
            _service = service;
        }

        public async Task<ResultPaging<GetClienteResponseDTO>> Handle(GetAllClientRequestDTO request, 
            CancellationToken cancellationToken)
        {
            try
            {
                //Faz a validação dos parâmetros de entrada
                GetAllClienteQueryValidator validator = new GetAllClienteQueryValidator();
                var validate = validator.Validate(request);

                if (validate.IsValid)
                {
                    var dto = _service.GetAll();
                    ActionResult.Response = SetPage(dto, request.PageCount, request.PageSize);
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

            return await Task.Run(() => ActionResult);
        }

    }
}
