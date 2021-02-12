using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Domain.Data.Entities;

namespace Sinaf.Domain.Data.Mappings
{
    public class RamoMap : IEntityTypeConfiguration<RamoEntity>
    {
        public void Configure(EntityTypeBuilder<RamoEntity> builder)
        {
            builder.ToTable("Ramo");
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Nome).HasColumnName("Nome");
            builder.HasKey(e => e.Id);
        }
    }
}
