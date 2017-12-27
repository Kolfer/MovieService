using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MoviesDomain.Abstract;
using System.Xml.Linq;
using MovieService.Models;
using MoviesDomain.Entities;
using MoviesDomain.Entities.AuthEntities;

namespace MovieService.Controllers
{
    public class Generator
    {
        IRepository repository;
        public Generator(IRepository repository)
        {
            this.repository = repository;
        }
        public IReadOnlyCollection<string> GetSitemapNodes(UrlHelper urlHelper)
        {
            List<string> nodes = new List<string>();

            nodes.Add(urlHelper.AbsoluteRouteUrl("Default", new { controller = "Home", action = "Index" }));
            nodes.Add(urlHelper.AbsoluteRouteUrl("Default", new { controller = "Home", action = "About" }));
            nodes.Add(urlHelper.AbsoluteRouteUrl("Default", new { controller = "Home", action = "Contact" }));
            nodes.Add(urlHelper.AbsoluteRouteUrl("Default", new { controller = "Authorize", action = "SignIn" }));
            nodes.Add(urlHelper.AbsoluteRouteUrl("Default", new { controller = "Authorize", action = "Register" }));
            nodes.Add(urlHelper.AbsoluteRouteUrl("Default", new { controller = "Genre", action = "AllGenres" }));
            nodes.Add(urlHelper.AbsoluteRouteUrl("Default", new { controller = "Movies", action = "TopMovies" }));
            nodes.Add(urlHelper.AbsoluteRouteUrl("Default", new { controller = "Persons", action = "PersonAll" }));
            nodes.Add(urlHelper.AbsoluteRouteUrl("Default", new { controller = "Genre", action = "AllGenres" }));


            foreach (int Id in repository.getIds<Movie>())
            {
                nodes.Add(urlHelper.AbsoluteRouteUrl("Default", new { controller = "Movies", action = "Movie", id = Id }));
            }
            foreach( int personId in repository.getIds<People>())
            {
                nodes.Add(urlHelper.AbsoluteRouteUrl("Default", new { controller = "Persons", action = "Person", id = personId }));
            }
            foreach (int Id in repository.getIds<Users>())
            {
                nodes.Add(urlHelper.AbsoluteRouteUrl("Default", new { controller = "Users", action = "Users", id = Id }));
            }
            foreach (string genre in repository.getItems<Genre>().Distinct().Select( g => g.Name) )
            {
                nodes.Add(urlHelper.AbsoluteRouteUrl("Default", new { controller = "Movies", action = "MoviesByGenre", id = genre }));
            }
            return nodes;
        }

        public string GetSitemapDocument(IEnumerable<string> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (string sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }
    }
    public static class UrlHelperExtensions
    {
        public static string AbsoluteRouteUrl(this UrlHelper urlHelper,
            string routeName, object routeValues = null)
        {
            string scheme = urlHelper.RequestContext.HttpContext.Request.Url.Scheme;
            return urlHelper.RouteUrl(routeName, routeValues, scheme);
        }
    }
}