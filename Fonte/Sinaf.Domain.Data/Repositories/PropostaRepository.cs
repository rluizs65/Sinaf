using EF.Base.Core.Repositories;
using EF.Base.Core.UnitOfWork;
using Sinaf.Domain.Data.Entities;
using Sinaf.Domain.Data.Repositories.Interfaces;

namespace Sinaf.Domain.Data.Repositories
{
    public class PropostaRepository : BaseRepository<PropostaEntity, long>, IPropostaRepository
    {
        public PropostaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }

}