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
    public class YorumController : Controller
    {
        IYorumService yorumServis;
        ITasitService tasitServis;
        public YorumController()
        {
            yorumServis = InstanceFactory.GetInstance<IYorumService>();
            tasitServis = InstanceFactory.GetInstance<ITasitService>();
        }
        // GET: Yorum
        public ActionResult Index()
        {
            return View("Home/Index");
        }

        [HttpPost]
        public ActionResult YorumEkle(Yorum entity)
        {
            try
            {
                yorumServis.Add(entity);
            }
            catch (Exception)
            {

            }

            return View("~/Views/Arac/OzelAracGetir.cshtml", tasitServis.GetEntity(c=>c.Id == entity.TasitId));
        }
    }
}