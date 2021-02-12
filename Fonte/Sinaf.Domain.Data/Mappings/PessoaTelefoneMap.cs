using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Domain.Data.Entities;

namespace Sinaf.Domain.Data.Mappings
{
    public class PessoaTelefoneMap : IEntityTypeConfiguration<PessoaTelefoneEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaTelefoneEntity> builder)
        {
            builder.ToTable("PessoaTelefone");
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Numero).HasColumnName("Numero");
            builder.Property(e => e.Ddd).HasColumnName("Ddd");
            builder.Property(e => e.Descricao).HasColumnName("Descricao");
            builder.Property(e => e.NumeroPrincipal).HasColumnName("NumeroPrincipal");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Pessoa).WithMany(e => e.PessoaTelefones).HasForeignKey("IdPessoa");
        }
    }
}
