using System;

namespace Sinaf.DTO.Responses
{
    public class PessoaResponseDTO
    {
        public long IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
    }
}
