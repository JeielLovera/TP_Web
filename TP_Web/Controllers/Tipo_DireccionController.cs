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
    public class Tipo_DireccionController : Controller
    {
        private ITipo_DireccionService tpdireccionService = new Tipo_DireccionService();

        // GET: Tipo_Direccion
        public ActionResult Index()
        {
            return View(tpdireccionService.FindAll());
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Tipo_Direccion tpdirec)
        {
            bool rpta = tpdireccionService.Insert(tpdirec);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}