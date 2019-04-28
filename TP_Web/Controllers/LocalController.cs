using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Business.Implementation;
using Entity;
namespace TP_PIZZA.Controllers
{
    public class LocalController : Controller
    {
        private ILocalService localservice = new LocalService();
        // GET: Local
        public ActionResult Index()
        {
            return View(localservice.FindAll());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Local loc)
        {
            bool rpta = localservice.Insert(loc);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}