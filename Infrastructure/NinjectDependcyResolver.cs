using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using MoviesDomain.Concrety;
using MoviesDomain.Abstract;
using AuthecantionWithCookie.Abstract;
using AuthecantionWithCookie.Concrete;
using MovieService.Models;

namespace MovieService.Infrastructure
{
    public class NinjectDependcyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependcyResolver()
        {
            kernel = new StandardKernel();
            addBinding();
        }

        public object GetService(Type type)
        {
            return kernel.TryGet(type);
        }

        public IEnumerable<object> GetServices(Type type)
        {
            return kernel.GetAll(type);
        }

        private void addBinding()
        {
            kernel.Bind<IRepository>().To<MovieRepositoryAuth>().InTransientScope();
            Type type = typeof(IRepository);
            kernel.Bind<IAuthecantion>().To<CustomAuthecantion>().InTransientScope()
                        .WithConstructorArgument("repository", GetService(type));
        }
    }
}