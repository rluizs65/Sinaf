using System;

namespace Sinaf.DTO.Responses
{
    public class GetAllClientResponseDTO
    {
        public long IdCliente { get; set; }
        public long IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
    }
}
