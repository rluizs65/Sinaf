using EF.Base.Core.Repositories;
using EF.Base.Core.UnitOfWork;
using EF.Base.Core.UnitOfWork;
using Sinaf.Domain.Data.Entities;
using Sinaf.Domain.Data.Repositories.Interfaces;
using System.Linq;

namespace Sinaf.Domain.Data.Repositories
{
    public class ApoliceRepository : BaseRepository<ApoliceEntity, long>, IApoliceRepository
    {
        public ApoliceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public ApoliceEntity GetByNumero(string numero)
        {
            ApoliceEntity result = GetAll()
                .Where(x => x.Numero == numero).FirstOrDefault();

            return result;
        }
    }

}
