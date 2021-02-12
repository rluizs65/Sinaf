using Microsoft.EntityFrameworkCore;
using Sinaf.Domain.Data.Mappings;
using System.ComponentModel.DataAnnotations;

namespace Sinaf.Domain.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();

            modelBuilder.ApplyConfiguration(new ApoliceMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new CoberturaMap());
            modelBuilder.ApplyConfiguration(new CorretorMap());
            modelBuilder.ApplyConfiguration(new DependenteMap());
            modelBuilder.ApplyConfiguration(new PessoaEnderecoMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new PessoaTelefoneMap());
            modelBuilder.ApplyConfiguration(new TipoCoberturaMap());
            modelBuilder.ApplyConfiguration(new PropostaDependenteMap());
            modelBuilder.ApplyConfiguration(new PropostaMap());
            modelBuilder.ApplyConfiguration(new RamoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
