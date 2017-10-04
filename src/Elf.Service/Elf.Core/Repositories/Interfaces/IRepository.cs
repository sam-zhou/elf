using System;
using System.Collections.Generic;

namespace Elf.Core.Repositories.Interfaces
{
    public interface IRepository
    {
        void SaveChanges();
    }

    public interface IRepository<T>: IRepository where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> where);
        T Single(Func<T, bool> where);
        T First(Func<T, bool> where);
        void Delete(T entity);
        void Add(T entity);
    }
}
