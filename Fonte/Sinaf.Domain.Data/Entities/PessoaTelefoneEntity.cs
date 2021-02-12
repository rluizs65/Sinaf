using Base.Core.Entities;

namespace Sinaf.Domain.Data.Entities
{
    public class PessoaTelefoneEntity : BaseEntity<long>
    {
        public PessoaTelefoneEntity()
        {

        }

        public virtual string Numero { get; set; }
        public virtual string Ddd { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool NumeroPrincipal { get; set; }
        public virtual PessoaEntity Pessoa { get; set; }
    }
}
