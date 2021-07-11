using Galeri.Business.Abstract;
using Galeri.Business.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Galeri.WebUI.Controllers
{
    public class HomeController : Controller
    {
        ITasitService tasitServis;

        public HomeController()
        {
            tasitServis = InstanceFactory.GetInstance<ITasitService>();
        }

        public ActionResult Index()
        {
            return View(tasitServis.GetEntities(null));
        }

        public PartialViewResult SolTanitim()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Filtrele(string textX)
        {
            var entities = tasitServis.GetEntities(c => c.Modeli.ModelAdi.ToLower() == textX.ToLower());
            return entities.Count() < 1 ? View("Index", tasitServis.GetEntities(null)) : View("Index", entities);
        }

    }
}