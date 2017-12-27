using System;
using AuthecantionWithCookie.Abstract;
using AuthecantionWithCookie.Concrete;
using System.Web.Mvc;
using MovieService.Models;
using MoviesDomain.Entities.AuthEntities;
using MoviesDomain.Abstract;

namespace MovieService.Controllers
{
    public class AuthorizeController : BaseController
    {
        private IRepository repositoryAuth;
        

        public AuthorizeController( IRepository repository, IAuthecantion authecantion)
            : base(authecantion)
        {
            repositoryAuth = repository;
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public ActionResult SignIn(LoginView view)
        {
            if(ModelState.IsValid)
            {
                var User = auth.Login(view.email, view.password, false);
                if (User != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState["Password"].Errors.Add("Password isn't valid");
            }
            return View(view);
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterView());
        }

        [HttpPost]
        public ActionResult Register(RegisterView view)
        {
            if (ModelState.IsValid && repositoryAuth.getUserFromEmail(view.email) == null)
            {
                Users user = new Users(view.Gender)
                {
                    Name = view.UserName,
                    Email = view.email,
                    Id = repositoryAuth.Count<Users>(),
                    UserPassword = view.password,
                    AddedDate = DateTime.Now,
                    LastVisitDate = DateTime.Now,
                    Country = view.Country,
                    City = view.City,
                };
                (repositoryAuth as IAuthecantionRepository).RegisterUser(user, "Authorized");
                var User = auth.Login(view.email, view.password, false);
                if(User != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(view);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            auth.LogOut();
            return RedirectToAction("Index", "Home");
        }

    }
}