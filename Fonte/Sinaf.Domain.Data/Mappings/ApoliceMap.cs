using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Domain.Data.Entities;

namespace Sinaf.Domain.Data.Mappings
{
    public class ApoliceMap : IEntityTypeConfiguration<ApoliceEntity>
    {
        public void Configure(EntityTypeBuilder<ApoliceEntity> builder)
        {
            builder.ToTable("Apolice");
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Numero).HasColumnName("Numero");
            builder.Property(e => e.DataInicioVigencia).HasColumnName("DataInicioVigencia");
            builder.Property(e => e.DataFimVigencia).HasColumnName("DataFimVigencia");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Proposta).WithOne(e => e.Apolice).HasForeignKey<ApoliceEntity>("IdProposta");
        }
    }
}
