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
    public class OrdenController : Controller
    {
        // GET: Orden
        private IOrdenService ordenService = new OrdenService();
        private IVentaService ventaService = new VentaService();
        public ActionResult Index()
        {
            return View(ordenService.FindAll());
        }
        // GET: Orden/Create
        public ActionResult Create()
        {
            ViewBag.ventaservice = ventaService.FindAll();
            return View();
        }

        // POST: Orden/Create
        [HttpPost]
        public ActionResult Create(Orden  orden)
        {
            ViewBag.ventaservice = ventaService.FindAll();
            bool rpta = ordenService.Insert(orden);
            if (rpta)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Orden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) { return HttpNotFound(); }
            ViewBag.ventaservice = ventaService.FindAll();
            Orden orden = ordenService.FindById(id);
            return View(orden);
        }

        // POST: Orden/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Orden orden)
        {
            if (!ModelState.IsValid) { return View(); }

            ViewBag.ventaservice = ventaService.FindAll();
            bool rpta = ordenService.Update(orden);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
