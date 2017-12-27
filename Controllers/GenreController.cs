using MoviesDomain.Abstract;
using MoviesDomain.Entities;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using MovieService.Models;


namespace MovieService.Controllers
{
    public class GenreController : Controller
    {
        IRepository repository;

        public GenreController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult AllGenres()
        {
            return View(repository.getItems<Genre>().getCurrentGenre());
        }
    }
}