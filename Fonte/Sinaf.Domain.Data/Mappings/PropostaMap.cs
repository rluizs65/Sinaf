using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinaf.Domain.Data.Entities;

namespace Sinaf.Domain.Data.Mappings
{
    public class PropostaMap : IEntityTypeConfiguration<PropostaEntity>
    {
        public void Configure(EntityTypeBuilder<PropostaEntity> builder)
        {
            builder.ToTable("Proposta");
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Numero).HasColumnName("Nome");
            builder.Property(e => e.DataEmissao).HasColumnName("DataEmissao");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Cliente).WithMany(e => e.Propostas).HasForeignKey("IdCliente");
            builder.HasOne(e => e.Corretor).WithMany(e => e.Propostas).HasForeignKey("IdCorretor");
            builder.HasOne(e => e.Ramo).WithMany(e => e.Propostas).HasForeignKey("IdRamo");
        }
    }
}
