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
    public class Producto_IngredienteController : Controller
    {
        private IProducto_IngredienteService prodct_ingrdntService = new Producto_IngredienteService();
        private IProductoService prodctService = new ProductoService();
        private IIngredienteService ingrdntService = new IngredienteService();

        // GET: Producto_Ingrediente
        public ActionResult Index()
        {
            return View(prodct_ingrdntService.FindAll());
        }

        public ActionResult Create()
        {
            ViewBag.producto = prodctService.FindAll();
            ViewBag.ingrediente = ingrdntService.FindAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto_Ingrediente prodct_ingrdnt)
        {
            ViewBag.producto = prodctService.FindAll();
            ViewBag.ingrediente = ingrdntService.FindAll();
            bool rpta = prodct_ingrdntService.Insert(prodct_ingrdnt);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}