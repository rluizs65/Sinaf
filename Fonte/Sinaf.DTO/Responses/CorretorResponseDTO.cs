using System;

namespace Sinaf.DTO.Responses
{
    public class CorretorResponseDTO
    {
        public long IdCorretor { get; set; }
        public long IdPessoa { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
    }
}
