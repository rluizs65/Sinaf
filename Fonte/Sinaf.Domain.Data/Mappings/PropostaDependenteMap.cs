using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Domain.Data.Entities;

namespace Sinaf.Domain.Data.Mappings
{
    public class PropostaDependenteMap : IEntityTypeConfiguration<PropostaDependenteEntity>
    {
        public void Configure(EntityTypeBuilder<PropostaDependenteEntity> builder)
        {
            builder.ToTable("PropostaDependente");
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Proposta).WithMany(e => e.PropostaDependentes).HasForeignKey("IdProposta");
            builder.HasOne(e => e.Dependente).WithOne(e => e.PropostaDependente).HasForeignKey<PropostaDependenteEntity>("IdDependente");
        }
    }
}
