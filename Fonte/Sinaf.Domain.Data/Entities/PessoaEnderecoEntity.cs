using Base.Core.Entities;

namespace Sinaf.Domain.Data.Entities
{
    public class PessoaEnderecoEntity : BaseEntity<long>
    {
        public PessoaEnderecoEntity()
        {

        }

        public virtual string Endereco { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string Cep { get; set; }
        public virtual string Uf { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Bairro { get; set; }
        public virtual PessoaEntity Pessoa { get; set; }
    }
}
