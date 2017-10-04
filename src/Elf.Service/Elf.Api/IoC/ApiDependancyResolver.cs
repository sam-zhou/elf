using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.Windsor;

namespace Elf.Api.IoC
{
    public class ApiDependancyResolver : IDependencyResolver
    {

        private readonly IWindsorContainer _container;

        public ApiDependancyResolver(IWindsorContainer container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public void Dispose()
        {
            //_container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType)
                ? _container.Resolve(serviceType)
                : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? _container.ResolveAll(serviceType).Cast<object>() : new object[] { };
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}