using Base.Core.Entities;

namespace Sinaf.Domain.Data.Entities
{
    public class TipoCoberturaEntity : BaseEntity<long>
    {
        public TipoCoberturaEntity()
        {

        }

        public virtual string Nome { get; set; }
        public virtual CoberturaEntity Cobertura { get; set; }
    }
}
