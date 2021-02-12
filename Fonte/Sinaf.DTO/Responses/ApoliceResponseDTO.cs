using System;

namespace Sinaf.DTO.Responses
{
    public class ApoliceResponseDTO
    {
        public long IdApolice { get; set; }
        public long IdProposta { get; set; }
        public string NumeroProposta { get; set; }
        public string NumeroApolice { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public DateTime DataFimVigencia { get; set; }
    }
}
