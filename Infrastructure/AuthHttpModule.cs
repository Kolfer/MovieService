using System;
using System.Web;
using System.Web.Mvc;
using AuthecantionWithCookie.Abstract;

namespace MovieService.Infrastructure
{
    public class AuthHttpModule : IHttpModule
    {
        //---------------------------------------------------------//

        public void Init(HttpApplication application)
        {
            application.AuthenticateRequest += new EventHandler(Authenticate);
        }

        //---------------------------------------------------------//

        private void Authenticate(object sender, EventArgs args)
        {
            HttpApplication sourse = sender as HttpApplication;
            HttpContext context = sourse.Context;

            var auth = DependencyResolver.Current.GetService<IAuthecantion>();
            auth.httpContext = context;
            context.User = auth.CurrentUser;
        }

        //---------------------------------------------------------//

        public void Dispose()
        {
            
        }
    }
}