using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zadatak1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Proizvodi()
        {
            return View();
        }

        public ActionResult Kategorije()
        {
            return View();
        }
        public ActionResult Potkategorije()
        {
            return View();
        }

        public ActionResult Racuni(int id)
        {
            return View(id);
        }

        public ActionResult Stavke(int id)
        {
            return View(id);
        }

    }
}