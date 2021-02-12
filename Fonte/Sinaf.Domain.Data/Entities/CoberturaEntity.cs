using Base.Core.Entities;

namespace Sinaf.Domain.Data.Entities
{
    public class CoberturaEntity : BaseEntity<long>
    {
        public CoberturaEntity() { }

        public virtual decimal LimiteMaximoIndenizacao { get; set; }
        public virtual decimal ValorPagoSegurado { get; set; }
        public virtual decimal ValorPremio { get; set; }
        public virtual PropostaEntity Proposta { get; set; }
        public virtual TipoCoberturaEntity TipoCobertura { get; set; }
    }
}
