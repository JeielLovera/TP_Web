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
    public class Venta_ProductoController : Controller
    {
        private IVenta_ProductoService venta_productoservice = new Venta_ProductoService();
        private IProductoService productoservice = new ProductoService();
        private IVentaService ventaservice = new VentaService();
        // GET: Venta_Producto
        public ActionResult Index()
        {
            return View(venta_productoservice.FindAll());
        }
        public ActionResult Create()
        {
            ViewBag.producto = productoservice.FindAll();
            ViewBag.venta = ventaservice.FindAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Venta_Producto ventaproducto)
        {
            ViewBag.producto = productoservice.FindAll();
            ViewBag.venta = ventaservice.FindAll();
            bool rpta = venta_productoservice.Insert(ventaproducto);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int?id)
        {
            ViewBag.producto = productoservice.FindAll();
            ViewBag.venta = ventaservice.FindAll();
            if (id==null)
            {
                return HttpNotFound();
            }
            Venta_Producto ventaprod = venta_productoservice.FindById(id);
            return View(ventaprod);
        }
        [HttpPost]
        public ActionResult Edit(Venta_Producto ventaprod)
        {
            ViewBag.producto = productoservice.FindAll();
            ViewBag.venta = ventaservice.FindAll();
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = venta_productoservice.Update(ventaprod);
            if(rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}