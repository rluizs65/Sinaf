using Base.Core.Entities;
using System.Collections.Generic;

namespace Sinaf.Domain.Data.Entities
{
    public class RamoEntity : BaseEntity<long>
    {
        public RamoEntity()
        {

        }

        public virtual string Nome { get; set; }
        public virtual IList<PropostaEntity> Propostas { get; set; }
    }
}
