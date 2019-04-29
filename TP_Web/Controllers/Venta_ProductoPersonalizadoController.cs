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
    }
}