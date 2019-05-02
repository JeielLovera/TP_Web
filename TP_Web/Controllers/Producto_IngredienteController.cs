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

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Producto_Ingrediente prodct_ingrdnt = prodct_ingrdntService.FindById(id);
            return View(prodct_ingrdnt);
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

        public ActionResult Edit(int? id)
        {
            ViewBag.producto = prodctService.FindAll();
            ViewBag.ingrediente = ingrdntService.FindAll();
            if (id == null)
            {
                return HttpNotFound();
            }
            Producto_Ingrediente prodct_ingrdnt = prodct_ingrdntService.FindById(id);
            return View(prodct_ingrdnt);
        }

        [HttpPost]
        public ActionResult Edit(Producto_Ingrediente prodct_ingrdnt)
        {
            ViewBag.producto = prodctService.FindAll();
            ViewBag.ingrediente = ingrdntService.FindAll();
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = prodct_ingrdntService.Update(prodct_ingrdnt);
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
            Producto_Ingrediente prodct_ingrdnt = prodct_ingrdntService.FindById(id);
            return View(prodct_ingrdnt);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = prodct_ingrdntService.Delete(id);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}