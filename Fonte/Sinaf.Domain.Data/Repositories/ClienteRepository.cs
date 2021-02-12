using EF.Base.Core.Repositories;
using EF.Base.Core.UnitOfWork;
using Sinaf.Domain.Data.Entities;
using Sinaf.Domain.Data.Repositories.Interfaces;
using System;

namespace Sinaf.Domain.Data.Repositories
{
    public class ClienteRepository : BaseRepository<ClienteEntity, long>, IClienteRepository
    {
        public ClienteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public ClienteEntity GetByNome(string nome)
        {
            ClienteEntity result = (ClienteEntity)Get(ClienteEntity => ClienteEntity.Pessoa.Nome == nome);

            return result;
        }

        public ClienteEntity GetByNomeENascimento(string nome, DateTime dataNascimento)
        {
            ClienteEntity result = (ClienteEntity)Get(ClienteEntity => 
            ClienteEntity.Pessoa.Nome == nome && ClienteEntity.Pessoa.DataNascimento == dataNascimento);

            return result;
        }
    }

}