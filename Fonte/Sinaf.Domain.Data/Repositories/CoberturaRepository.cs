using EF.Base.Core.Repositories;
using EF.Base.Core.UnitOfWork;
using Sinaf.Domain.Data.Entities;
using Sinaf.Domain.Data.Repositories.Interfaces;

namespace Sinaf.Domain.Data.Repositories
{
    public class CoberturaRepository : BaseRepository<CoberturaEntity, long>, ICoberturaRepository
    {
        public CoberturaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }

}