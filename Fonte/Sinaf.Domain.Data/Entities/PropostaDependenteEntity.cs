using Base.Core.Entities;

namespace Sinaf.Domain.Data.Entities
{
    public class PropostaDependenteEntity : BaseEntity<long>
    {
        public PropostaDependenteEntity() { }

        public virtual PessoaEntity Pessoa { get; set; }
        public virtual PropostaEntity Proposta { get; set; }
        public virtual DependenteEntity Dependente { get; set; }
    }
}
