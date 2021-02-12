using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Base.Core.Controllers;
using Sinaf.DTO.Requests;
using Base.Core.Enumerators;

namespace Sinaf.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : BaseController
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna lista de todos os clientes
        /// </summary>
        /// <param name="request">Parâmetros de entrada</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTodosClientes")]
        public async Task<IActionResult> GetAllCliente([FromQuery] GetAllClientRequestDTO request)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(request);

                if (result.IsValid)
                    return Ok(result.Response);
                else
                    return BadRequest(result.Errors);
            }
            return BadRequest(ModelState.IsValid);
        }

        /// <summary>
        /// Retorna cliente pelo nome
        /// </summary>
        /// <param name="request">Nome do cliente</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetClientePorNome")]
        public async Task<IActionResult> GetClienteByNome([FromQuery] GetClientByNomeRequestDTO request)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(request);

                if (result.IsValid)
                    return Ok(result.Response);
                else
                    return BadRequest(result.Errors);
            }
            return BadRequest(ModelState.IsValid);
        }

    }
}
