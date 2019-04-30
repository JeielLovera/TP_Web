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
    public class RolController : Controller
    {
        private IRolService rolservice = new RolService();
        // GET: Rol
        public ActionResult Index()
        {
            return View(rolservice.FindAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Rol rol = rolservice.FindById(id);
            return View(rol);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Rol rol)
        {
            bool rpta = rolservice.Insert(rol);
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
            Rol rol = rolservice.FindById(id);
            return View(rol);
        }

        [HttpPost]
        public ActionResult Edit(Rol rol)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = rolservice.Update(rol);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}