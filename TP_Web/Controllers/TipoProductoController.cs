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
    public class TipoProductoController : Controller
    {
        private ITipoProductoService tipoproductoservice = new TipoProductoService();
        // GET: TipoProducto
        public ActionResult Index()
        {
            return View(tipoproductoservice.FindAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            TipoProducto tp = tipoproductoservice.FindById(id);
            return View(tp);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TipoProducto tp)
        {

            bool rpta = tipoproductoservice.Insert(tp);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            TipoProducto tp = tipoproductoservice.FindById(id);
            return View(tp);
        }

        [HttpPost]
        public ActionResult Edit(TipoProducto tp)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = tipoproductoservice.Update(tp);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}