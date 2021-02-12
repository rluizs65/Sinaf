using Microsoft.EntityFrameworkCore;
using System;

namespace EF.Base.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public DbContext Context { get; }
        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}
