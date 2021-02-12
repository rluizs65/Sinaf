using Base.Core.Entities;
using System.Collections.Generic;

namespace Sinaf.Domain.Data.Entities
{
    public class CorretorEntity : BaseEntity<long>
    {
        public CorretorEntity() { }

        public virtual string Codigo { get; set; }
        public virtual PessoaEntity Pessoa { get; set; }
        public virtual IList<PropostaEntity> Propostas { get; set; }
    }
}
