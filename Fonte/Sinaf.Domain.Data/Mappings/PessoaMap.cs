using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Domain.Data.Entities;

namespace Sinaf.Domain.Data.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaEntity> builder)
        {
            builder.ToTable("Pessoa");
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Nome).HasColumnName("Nome");
            builder.Property(e => e.Cpf).HasColumnName("Cpf");
            builder.Property(e => e.Cnpj).HasColumnName("Cnpj");
            builder.Property(e => e.DataNascimento).HasColumnName("DataNascimento");
            builder.Property(e => e.Sexo).HasColumnName("Sexo");
            builder.Property(e => e.Email).HasColumnName("Email");
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Clientes).WithOne(e => e.Pessoa).HasForeignKey("IdPessoa");
        }
    }
}
