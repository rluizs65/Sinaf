using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Domain.Data.Entities;

namespace Sinaf.Domain.Data.Mappings
{
    public class TipoCoberturaMap : IEntityTypeConfiguration<TipoCoberturaEntity>
    {
        public void Configure(EntityTypeBuilder<TipoCoberturaEntity> builder)
        {
            builder.ToTable("TipoCobertura");
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Nome).HasColumnName("Nome");
            builder.HasKey(e => e.Id);
        }
    }
}
