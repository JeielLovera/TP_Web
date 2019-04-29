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
    public class ProductoController : Controller
    {
        private IProductoService productoservice = new ProductoService();
        private ITipoProductoService tpproductoservice = new TipoProductoService();
        // GET: Producto
        public ActionResult Index()
        {
            return View(productoservice.FindAll());
        }
        public ActionResult Create()
        {
            ViewBag.tpproducto = tpproductoservice.FindAll();
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null) { return HttpNotFound(); }
            ViewBag.tpproducto = tpproductoservice.FindAll();
            Producto producto = productoservice.FindById(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Create(Producto prod)
        {
            ViewBag.tpproducto = tpproductoservice.FindAll();
            bool rpta = productoservice.Insert(prod);
            if (rpta)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Producto prod)
        {
            if (!ModelState.IsValid) { return View(); }

            ViewBag.tpproducto = tpproductoservice.FindAll();
            bool rpta = productoservice.Update(prod);

            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}