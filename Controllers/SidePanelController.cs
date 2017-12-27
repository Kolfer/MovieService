using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieService.Controllers
{
    public class SidePanelController : Controller
    {
        // GET: SidePanel
        public ActionResult Index()
        {
            return View();
        }
    }
}