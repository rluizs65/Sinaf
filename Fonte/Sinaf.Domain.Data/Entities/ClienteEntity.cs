using Base.Core.Entities;
using System.Collections.Generic;

namespace Sinaf.Domain.Data.Entities
{
    public class ClienteEntity : BaseEntity<long>
    {
        public ClienteEntity() { }
        public virtual PessoaEntity Pessoa { get; set; }
        public virtual IList<DependenteEntity> Dependentes { get; set; }
        public virtual IList<PropostaEntity> Propostas { get; set; }
    }
}
