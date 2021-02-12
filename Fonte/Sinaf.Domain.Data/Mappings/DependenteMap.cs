using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Domain.Data.Entities;

namespace Sinaf.Domain.Data.Mappings
{
    public class DependenteMap : IEntityTypeConfiguration<DependenteEntity>
    {
        public void Configure(EntityTypeBuilder<DependenteEntity> builder)
        {
            builder.ToTable("Dependente");
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Pessoa).WithMany(e => e.Dependentes).HasForeignKey("IdPessoa");
        }
    }
}
