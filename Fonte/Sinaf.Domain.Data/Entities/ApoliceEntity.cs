using Base.Core.Entities;
using System;

namespace Sinaf.Domain.Data.Entities
{
    public class ApoliceEntity : BaseEntity<long>
    {
        public ApoliceEntity() { }

        public virtual string Numero { get; set; }
        public virtual DateTime DataInicioVigencia { get; set; }
        public virtual DateTime DataFimVigencia { get; set; }
        public virtual PropostaEntity Proposta { get; set; }
    }
}
