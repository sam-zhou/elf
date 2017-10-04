using System;
using System.Collections;
using System.Threading;
using System.Web;

namespace Elf.Core.Uow
{
    public class UnitOfWork
    {
        private const string Httpcontextkey = "Elf.Core.HttpContext.Key";

        private static IUnitOfWorkFactory _unitOfWorkFactory;
        private static readonly Hashtable Threads = new Hashtable();
        public static void Commit()
        {
            IUnitOfWork unitOfWork = GetUnitOfWork();
            unitOfWork?.Commit();
        }
        
        private static IUnitOfWork GetUnitOfWork()
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items.Contains(Httpcontextkey))
                {
                    return (IUnitOfWork)HttpContext.Current.Items[Httpcontextkey];
                }
                return null;
            }
            else
            {
                Thread thread = Thread.CurrentThread;
                if (string.IsNullOrEmpty(thread.Name))
                {
                    thread.Name = Guid.NewGuid().ToString();
                    return null;
                }
                else
                {
                    lock (Threads.SyncRoot)
                    {
                        return (IUnitOfWork)Threads[Thread.CurrentThread.Name ?? throw new InvalidOperationException()];
                    }
                }
            }
        }
        private static void SaveUnitOfWork(IUnitOfWork unitOfWork)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items[Httpcontextkey] = unitOfWork;
            }
            else
            {
                lock (Threads.SyncRoot)
                {
                    Threads[Thread.CurrentThread.Name ?? throw new InvalidOperationException()] = unitOfWork;
                }
            }
        }
    }
}
