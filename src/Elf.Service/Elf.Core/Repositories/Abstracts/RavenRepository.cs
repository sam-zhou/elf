using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elf.Core.Repositories.Interfaces;
using Elf.Core.Uow;
using Raven.Client;

namespace Elf.Core.Repositories.Abstracts
{
    public class RavenRepository<T> : IRepository<T> where T : class
    {
        private IDocumentSession _context;
        protected IDocumentSession Context
        {
            get
            {
                if (_context == null)
                {
                    _context = UnitOfWork.Context;
                }
                return _context;
            }
        }

        protected RavenUnitOfWork UnitOfWork { get; private set; }

        public RavenRepository(IUnitOfWork unitOfWork) {
            UnitOfWork = unitOfWork as RavenUnitOfWork;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Query<T>();
        }
        public IEnumerable<T> Find(Func<T, bool> where)
        {
            return this.Context.Query<T>().Where<T>(where);
        }
        public T Single(Func<T, bool> where)
        {
            return this.Context.Query<T>().SingleOrDefault<T>(where);
        }
        public T First(Func<T, bool> where)
        {
            return this.Context.Query<T>().First<T>(where);
        }
        public virtual void Delete(T entity)
        {
            this.Context.Delete(entity);
        }
        public virtual void Add(T entity)
        {
            this.Context.Store(entity);
        }
        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}
