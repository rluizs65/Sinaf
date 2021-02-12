using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Base.Core.Controllers;
using Sinaf.DTO.Requests;
using EF.Base.Core.UnitOfWork;
using Base.Core.Enumerators;

namespace Sinaf.API.Controllers
{
    /// <summary>
    /// API de Pessoas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;
//        private readonly IUnitOfWork _unitOfWork;

        public PessoaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Atualiza dados de uma pessoa
        /// </summary>
        /// <param name="request">Parâmetros de entrada</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AtualizaPessoa")]
        public async Task<IActionResult> Post(UpdatePessoaRequestDTO request)
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
        /// Inclui uma nova pessoa
        /// </summary>
        /// <param name="request">Parâmetros de entrada</param>
        /// <returns></returns>
        [HttpPut]
        [Route("IncluirPessoa")]
        public async Task<IActionResult> Put(AddPessoaRequestDTO request)
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
        /// Remove registro de uma pessoa
        /// </summary>
        /// <param name="request">Id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("RemovePessoa")]
        public async Task<IActionResult> Delete(DeletePessoaRequestDTO request)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(request);

                if (result.IsValid)
                    return Ok(result.IsValid);
                else
                    return BadRequest(result.Errors);
            }
            return BadRequest(ModelState.IsValid);
        }
    }
}
