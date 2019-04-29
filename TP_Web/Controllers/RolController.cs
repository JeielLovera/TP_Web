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
    }
}