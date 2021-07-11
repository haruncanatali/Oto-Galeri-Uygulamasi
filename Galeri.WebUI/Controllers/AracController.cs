using Galeri.Business.Abstract;
using Galeri.Business.Ninject;
using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Galeri.WebUI.Controllers
{
    public class AracController : Controller
    {
        ITasitService tasitServis;
        public AracController()
        {
            tasitServis = InstanceFactory.GetInstance<ITasitService>();
        }

        public ActionResult Index()
        {
            return View("/Home/Index");
        }

        [HttpGet]
        public ActionResult OzelAracGetir(int id)
        {
            return View(tasitServis.GetEntity(c=>c.Id == id));
        }
    }
}