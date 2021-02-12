using Base.Core.Entities;
using System;
using System.Collections.Generic;

namespace Sinaf.Domain.Data.Entities
{
    public class PropostaEntity : BaseEntity<long>
    {
        public PropostaEntity() { }

        public virtual string Numero { get; set; }
        public virtual DateTime DataEmissao { get; set; }
        public virtual ClienteEntity Cliente { get; set; }
        public virtual ApoliceEntity Apolice { get; set; }
        public virtual RamoEntity Ramo { get; set; }
        public virtual CorretorEntity Corretor { get; set; }
        public virtual IList<PropostaDependenteEntity> PropostaDependentes { get; set; }
        public virtual IList<CoberturaEntity> Coberturas { get; set; }
    }
}
