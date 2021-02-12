using EF.Base.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sinaf.Domain.Data.Contexts;

namespace Sinaf.Domain.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }
        private IDbContextTransaction _transaction;

        public UnitOfWork(DataContext context)
        {
            Context = context;
        }

        public void BeginTransaction()
        {
            _transaction = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                Context.SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
