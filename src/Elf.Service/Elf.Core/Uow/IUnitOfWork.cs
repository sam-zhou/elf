using System;

namespace Elf.Core.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
