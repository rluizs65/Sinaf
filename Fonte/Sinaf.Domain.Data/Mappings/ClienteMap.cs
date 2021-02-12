using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Domain.Data.Entities;

namespace Sinaf.Domain.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("Cliente");
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Pessoa).WithMany(e => e.Clientes).HasForeignKey("IdPessoa");        
        }
    }
}
