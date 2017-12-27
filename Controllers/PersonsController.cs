using MoviesDomain.Abstract;
using System.Web.Mvc;
using MoviesDomain.Entities;
using System.Linq;
using MovieService.Models;
using System;
using System.Collections.Generic;


namespace MovieService.Controllers
{
    public class PersonsController : Controller
    {
        private IRepository repository;

        const int PersonOnPage = 8;

        public PersonsController( IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult PersonAll(int page = 1)
        {
            var allPeople = repository.getItems<People>().Distinct().ToList();
            var peoples =  allPeople.OrderByDescending((p) => p.Popularity);
            PeopleListModel people = new PeopleListModel()
            {
                people = peoples
                .Skip((page - 1) * PersonOnPage).Take(PersonOnPage),
                pagingInfo = new PagingInfo(page, PersonOnPage, peoples.Count())
            };

            return View(people);
        }


        [HttpGet]
        public ActionResult Person(int id)
        {
            var person = repository.findItem<People>(id);
            if( person == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(person);
        }
    }
}