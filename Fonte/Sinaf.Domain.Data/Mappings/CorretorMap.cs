using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Domain.Data.Entities;

namespace Sinaf.Domain.Data.Mappings
{
    public class CorretorMap : IEntityTypeConfiguration<CorretorEntity>
    {
        public void Configure(EntityTypeBuilder<CorretorEntity> builder)
        {
            builder.ToTable("Corretor");
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Codigo).HasColumnName("Codigo");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Pessoa).WithMany(e => e.Corretores).HasForeignKey("IdPessoa");
        }
    }
}
