using MoviesDomain.Abstract;
using System.Web.Mvc;
using MoviesDomain.Entities;
using System.Linq;
using System.Collections.Generic;
using MovieService.Models;
using System;
using System.Linq.Expressions;

namespace MovieService.Controllers
{
    public class MoviesController : Controller
    {
        private IRepository repository;

        const int ItemsPerPage = 8;

        public MoviesController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult TopMovies()
        {
           var pair = new Tuple<List<Genre>, IQueryable<Movie>>
                (repository.getItems<Genre>().getCurrentGenre(), repository.getItems<Movie>());
            return View(pair);
        }

        public ActionResult MoviesByGenre(string genre)
        {
            ViewBag.Genre = genre;
            Genre g = repository.findItem<Genre>(genre);
            var movies = repository.getItems<Movie>().ToList()
                .Where((m) => m.Genre.Contains(g));
            var pair = new KeyValuePair<List<Genre>, IEnumerable<Movie>>
                (repository.getItems<Genre>().getCurrentGenre(), movies);
            return View("TopMovies", pair);
        }


        public ActionResult Genre(string genre, int page = 1)
        {

            ViewBag.Genre = genre;

            Genre g = repository.findItem<Genre>(genre);
            var movies = repository.getItems<Movie>().ToList();
            var mov =    movies.Where((m) => m.Genre.Contains(g));

            var pair = new Tuple<PagingInfo, IEnumerable<Movie>>
                (new PagingInfo(page, ItemsPerPage, movies.Count()),
                mov.Skip((page - 1) * ItemsPerPage).Take(ItemsPerPage));
            return View(pair);
        }


        public ActionResult Movie(int id)
        {
            var movie = repository.findItem<Movie>(id);
            if ( movie == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(movie);
        }
    }
}