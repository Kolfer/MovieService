using AuthecantionWithCookie.Abstract;
using System.Web.Mvc;
using MoviesDomain.Abstract;
using MoviesDomain.Entities;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.IO;

namespace MovieService.Controllers
{
    public class HomeController : BaseController
    {
        IRepository repository;

        public HomeController(IRepository repository, IAuthecantion authecantion)
            : base(authecantion)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserLogin()
        {
            return PartialView(CurrentUser);
        }

        public ActionResult Sitemap()
        {
            Generator sitemapGenerator = new Generator(repository);
            var sitemapNodes = sitemapGenerator.GetSitemapNodes(Url);
            string xml = sitemapGenerator.GetSitemapDocument(sitemapNodes);
            return Content(xml, "text/xml", Encoding.UTF8);
        }

        //public ActionResult Robots()
        //{
        //    return File(@"/robots.txt", "application/text", "robots.txt");
        //}

        public ActionResult Search(string query)
        {
            var tuple = new Tuple<IEnumerable<Movie>, IEnumerable<People>>(
                repository.getItems<Movie>(query),
                repository.getItems<People>(query));

            ViewBag.Query = query;
            return View(tuple);
        }
    }
}