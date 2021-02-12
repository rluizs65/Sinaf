namespace Sinaf.DTO.Responses
{
    public class PessoaTelefoneResponseDTO
    {
        public long IdPessoaTelefone { get; set; }
        public long IdPessoa { get; set; }
        public string Numero { get; set; }
        public string Ddd { get; set; }
        public string Descricao { get; set; }
        public bool NumeroPrincipal { get; set; }
    }
}
