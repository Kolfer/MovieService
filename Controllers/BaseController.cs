using AuthecantionWithCookie.Abstract;
using System.Web.Mvc;
using MoviesDomain.Entities.AuthEntities;
using AuthecantionWithCookie.Concrete;
using System.Security.Principal;

namespace MovieService.Controllers
{
    public abstract class BaseController : Controller
    {
        public IAuthecantion auth;

        public BaseController(IAuthecantion authecantion)
        {
            auth = authecantion;
        }

        public IUser CurrentUser
        {
            get
            {
                IPrincipal principal = auth.CurrentUser;
                return (principal == null) ? null
                    :(principal.Identity as IUserProvider).user;
            }
        }

    }
}