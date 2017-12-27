using System;
using Ninject;
using Ninject.Modules;
using MoviesDomain.Concrety;
using MoviesDomain.Abstract;
using AuthecantionWithCookie.Abstract;
using AuthecantionWithCookie.Concrete;


namespace MovieService.Infrastructure
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<MovieRepository>();
            Bind<IAuthecantion>().To<CustomAuthecantion>();
        }
    }
}