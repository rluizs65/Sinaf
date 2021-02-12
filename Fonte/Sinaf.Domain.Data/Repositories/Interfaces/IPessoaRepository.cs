using EF.Base.Core.Repositories;
using Sinaf.Domain.Data.Entities;

namespace Sinaf.Domain.Data.Repositories.Interfaces
{
    public interface IPessoaRepository : IRepository<PessoaEntity, long>
    {
    }
}
