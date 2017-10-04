using System;
using Raven.Client;

namespace Elf.Core.Uow
{
    public class RavenUnitOfWork : IUnitOfWork
    {
        public IDocumentSession Context { get; private set; }
        public RavenUnitOfWork(IDocumentStore session)
        {
            Context = session.OpenSession();
        }
        #region IUnitOfWork Members
        public void Commit()
        {
            Context.SaveChanges();
        }
        #endregion
        #region IDisposable Members
        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
