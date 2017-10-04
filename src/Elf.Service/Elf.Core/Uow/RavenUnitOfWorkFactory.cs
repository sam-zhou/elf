using System;
using Raven.Client;

namespace Elf.Core.Uow
{
    public class RavenUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private static Func<IDocumentStore> _objectContextDelegate;
        private static readonly Object LockObject = new Object();
        public static void SetObjectContext(Func<IDocumentStore> objectContextDelegate)
        {
            _objectContextDelegate = objectContextDelegate;
        }
        #region IUnitOfWorkFactory Members
        public IUnitOfWork Create()
        {
            IDocumentStore context;
            lock (LockObject)
            {
                context = _objectContextDelegate();
            }
            return new RavenUnitOfWork(context);
        }
        #endregion
    }
}
