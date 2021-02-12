using Base.Core.Entities;

namespace Sinaf.Domain.Data.Entities
{
    public class DependenteEntity : BaseEntity<long>
    {
        public DependenteEntity() { }

        public virtual PessoaEntity Pessoa { get; set; }
        public virtual ClienteEntity Cliente { get; set; }
        public virtual PropostaDependenteEntity PropostaDependente { get; set; }
    }
}
