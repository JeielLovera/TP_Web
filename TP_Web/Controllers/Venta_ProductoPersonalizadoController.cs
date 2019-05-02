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
    public class Venta_ProductoPersonalizadoController : Controller
    {
        private IVenta_ProductoPersonalizadoService ventprodctperService = new Venta_ProductoPersonalizadoService();
        private IVentaService ventaService = new VentaService();
        private IIngredienteService ingrdntService = new IngredienteService();

        // GET: Venta_ProductoPersonalizado
        public ActionResult Index()
        {
            return View(ventprodctperService.FindAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Venta_ProductoPersonalizado venta_proper = ventprodctperService.FindById(id);
            return View(venta_proper);
        }

        public ActionResult Create()
        {
            ViewBag.venta = ventaService.FindAll();
            ViewBag.ingrediente = ingrdntService.FindAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Venta_ProductoPersonalizado ventprodctper)
        {
            ViewBag.venta = ventaService.FindAll();
            ViewBag.ingrediente = ingrdntService.FindAll();
            bool rpta = ventprodctperService.Insert(ventprodctper);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.venta = ventaService.FindAll();
            ViewBag.ingrediente = ingrdntService.FindAll();
            if (id == null)
            {
                return HttpNotFound();
            }
            Venta_ProductoPersonalizado ventaper = ventprodctperService.FindById(id);
            return View(ventaper);
        }
        [HttpPost]
        public ActionResult Edit(Venta_ProductoPersonalizado ventaper)
        {
            ViewBag.venta = ventaService.FindAll();
            ViewBag.ingrediente = ingrdntService.FindAll();
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = ventprodctperService.Update(ventaper);
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
            Venta_ProductoPersonalizado ventaper = ventprodctperService.FindById(id);
            return View(ventaper);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = ventprodctperService.Delete(id);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}