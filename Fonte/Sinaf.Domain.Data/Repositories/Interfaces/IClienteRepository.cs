using EF.Base.Core.Repositories;
using Sinaf.Domain.Data.Entities;
using System;

namespace Sinaf.Domain.Data.Repositories.Interfaces
{
    public interface IClienteRepository : IRepository<ClienteEntity, long>
    {
        ClienteEntity GetByNome(string nome);
        ClienteEntity GetByNomeENascimento(string nome, DateTime dataNascimento);
    }
}
