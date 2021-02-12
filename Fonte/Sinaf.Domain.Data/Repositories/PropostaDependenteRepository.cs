using EF.Base.Core.Repositories;
using EF.Base.Core.UnitOfWork;
using Sinaf.Domain.Data.Entities;
using Sinaf.Domain.Data.Repositories.Interfaces;

namespace Sinaf.Domain.Data.Repositories
{
    public class PropostaDependenteRepository : BaseRepository<PropostaDependenteEntity, long>, IPropostaDependenteRepository
    {
        public PropostaDependenteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }

}