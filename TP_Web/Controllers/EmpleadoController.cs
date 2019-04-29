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
    public class EmpleadoController : Controller
    {
        private IEmpleadoService empleadoService = new EmpleadoService();
        private IRolService rolService = new RolService();
        private IEmpleadoService jefeService = new EmpleadoService();

        // GET: Empleado
        public ActionResult Index()
        {

            return View(empleadoService.FindAll());
        }

        public ActionResult Create()
        {
            ViewBag.rol = rolService.FindAll();
            ViewBag.jefe = jefeService.FindAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Empleado empl)
        {
            ViewBag.rol = rolService.FindAll();
            ViewBag.jefe = jefeService.FindAll();
            bool rpta = empleadoService.Insert(empl);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.rol = rolService.FindAll();
            ViewBag.jefe = jefeService.FindAll();
            if (id == null)
            {
                return HttpNotFound();
            }
            Empleado empl = empleadoService.FindById(id);
            return View(empl);
        }

        [HttpPost]
        public ActionResult Edit(Empleado empl)
        {
            ViewBag.rol = rolService.FindAll();
            ViewBag.jefe = jefeService.FindAll();
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = empleadoService.Update(empl);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}