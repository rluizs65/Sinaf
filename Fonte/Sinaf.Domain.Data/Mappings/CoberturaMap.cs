using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Domain.Data.Entities;

namespace Sinaf.Domain.Data.Mappings
{
    public class CoberturaMap : IEntityTypeConfiguration<CoberturaEntity>
    {
        public void Configure(EntityTypeBuilder<CoberturaEntity> builder)
        {
            builder.ToTable("Cobertura");
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.LimiteMaximoIndenizacao).HasColumnName("LimiteMaximoIndenizacao");
            builder.Property(e => e.ValorPagoSegurado).HasColumnName("ValorPagoSegurado");
            builder.Property(e => e.ValorPremio).HasColumnName("ValorPremio");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.TipoCobertura).WithOne(e => e.Cobertura).HasForeignKey<CoberturaEntity>("IdTipoCobertura");
            builder.HasOne(e => e.Proposta).WithMany(e => e.Coberturas).HasForeignKey("IdProposta");

        }
    }
}
