using EF.Base.Core.Repositories;
using EF.Base.Core.UnitOfWork;
using Sinaf.Domain.Data.Entities;
using Sinaf.Domain.Data.Repositories.Interfaces;

namespace Sinaf.Domain.Data.Repositories
{
    public class RamoRepository : BaseRepository<RamoEntity, long>, IRamoRepository
    {
        public RamoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }

}