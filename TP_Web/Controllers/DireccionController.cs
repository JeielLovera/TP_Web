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
    public class DireccionController : Controller
    {
        private IDireccionService direccionservice = new DireccionService();
        private ITipo_DireccionService tpdirecService = new Tipo_DireccionService();
        private IDistritoService distritoservice = new DistritoService();
        // GET: Direccion
        public ActionResult Index()
        {
            return View(direccionservice.FindAll());
        }

        public ActionResult Create()
        {
            ViewBag.tipodirec = tpdirecService.FindAll();
            ViewBag.distrito = distritoservice.FindAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Direccion direc)
        {
            ViewBag.tipodirec = tpdirecService.FindAll();
            ViewBag.distrito = distritoservice.FindAll();
            bool rpta = direccionservice.Insert(direc);
            if(rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}