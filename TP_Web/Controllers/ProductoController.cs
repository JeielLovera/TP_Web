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
        private IProductoService productoService = new ProductoService();
        private ITipoProductoService tpproductoService = new TipoProductoService();
        
        // GET: Producto
        public ActionResult Index()
        {
            return View(productoService.FindAll());
        }

        public ActionResult Create()
        {
            ViewBag.tipoproducto = tpproductoService.FindAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            ViewBag.tipoproducto = productoService.FindAll();
            bool rpta = productoService.Insert(producto);
            if (rpta)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}