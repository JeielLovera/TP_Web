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
    public class DireccionController : Controller
    {
        private IDireccionService direccionservice = new DireccionService();
        private ITipo_DireccionService tpdirecService = new Tipo_DireccionService();
        private IDistritoService distritoservice = new DistritoService();
        // GET: Direccion
        public ActionResult Index()
        {
            return View(direccionservice.FindAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Direccion direccion = direccionservice.FindById(id);
            return View(direccion);
        }

        public ActionResult Create()
        {
            ViewBag.tipodirec = tpdirecService.FindAll();
            ViewBag.distrito = distritoservice.FindAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Direccion direc)
        {
            ViewBag.tipodirec = tpdirecService.FindAll();
            ViewBag.distrito = distritoservice.FindAll();
            bool rpta = direccionservice.Insert(direc);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.tipodirec = tpdirecService.FindAll();
            ViewBag.distrito = distritoservice.FindAll();
            if (id == null)
            {
                return HttpNotFound();
            }
            Direccion direccion = direccionservice.FindById(id);

            return View(direccion);
        }

        [HttpPost]
        public ActionResult Edit(Direccion direccion)
        {
            ViewBag.tipodirec = tpdirecService.FindAll();
            ViewBag.distrito = distritoservice.FindAll();
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = direccionservice.Update(direccion);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Direccion direccion = direccionservice.FindById(id);
            return View(direccion);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = direccionservice.Delete(id);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}