using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Domain.Data.Entities;

namespace Sinaf.Domain.Data.Mappings
{
    public class PessoaEnderecoMap : IEntityTypeConfiguration<PessoaEnderecoEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaEnderecoEntity> builder)
        {
            builder.ToTable("PessoaEndereco");
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Endereco).HasColumnName("Endereco");
            builder.Property(e => e.Numero).HasColumnName("Numero");
            builder.Property(e => e.Complemento).HasColumnName("Complemento");
            builder.Property(e => e.Cep).HasColumnName("Cep");
            builder.Property(e => e.Uf).HasColumnName("Uf");
            builder.Property(e => e.Cidade).HasColumnName("Cidade");
            builder.Property(e => e.Bairro).HasColumnName("Bairro");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Pessoa).WithMany(e => e.PessoaEnderecos).HasForeignKey("IdPessoa");
        }
    }
}
