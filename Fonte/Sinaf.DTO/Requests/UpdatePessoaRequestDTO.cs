using Base.Core.Results;
using MediatR;
using Sinaf.DTO.Responses;
using System;

namespace Sinaf.DTO.Requests
{
    public class UpdatePessoaRequestDTO : IRequest<Result<PessoaResponseDTO>>
    {
        public virtual long IdPessoa { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string Sexo { get; set; }
        public virtual string Email { get; set; }
    }
}
