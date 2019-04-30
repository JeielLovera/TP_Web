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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Local local = localservice.FindById(id);
            return View(local);
        }

        [HttpPost]
        public ActionResult Edit(Local local)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = localservice.Update(local);
            if(rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Local local = localservice.FindById(id);
            return View(local);
        }
    }
}