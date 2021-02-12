using Base.Core.Entities;
using System;
using System.Collections.Generic;

namespace Sinaf.Domain.Data.Entities
{
    public class PessoaEntity : BaseEntity<long>
    {
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string Sexo { get; set; }
        public virtual string Email { get; set; }
        public virtual IList<PessoaEnderecoEntity> PessoaEnderecos { get; set; }
        public virtual IList<PessoaTelefoneEntity> PessoaTelefones { get; set; }
        public virtual IList<ClienteEntity> Clientes { get; set; }
        public virtual IList<CorretorEntity> Corretores { get; set; }
        public virtual IList<DependenteEntity> Dependentes { get; set; }
    }
}