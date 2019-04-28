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
        private ITipoProductoService sbtipoproductoservice = new TipoProductoService();
        // GET: TipoProducto
        public ActionResult Index()
        {
            return View(tipoproductoservice.FindAll());
        }

        public ActionResult Create()
        {
            ViewBag.sbtpproducto = sbtipoproductoservice.FindAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(TipoProducto tp)
        {
            ViewBag.sbtpproducto = sbtipoproductoservice.FindAll();
            bool rpta = tipoproductoservice.Insert(tp);
            if(rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}