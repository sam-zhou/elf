namespace Elf.Core.Uow
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
