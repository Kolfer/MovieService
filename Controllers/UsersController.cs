using MoviesDomain.Entities.AuthEntities;
using System.Web.Mvc;
using MoviesDomain.Abstract;
using AuthecantionWithCookie.Abstract;

namespace MovieService.Controllers
{
    public class UsersController : BaseController
    {

        IRepository repository;

        //----------------------------------------------------------------//

        public UsersController(IRepository repository, IAuthecantion authecantionRepository)
         : base(authecantionRepository)
        {
            this.repository = repository;
        }

        //----------------------------------------------------------------//

        [HttpGet]
        public ActionResult Users(int id)
        {
            Users user = repository.findItem<Users>(id);
            if( user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        //----------------------------------------------------------------//

        

    }
}