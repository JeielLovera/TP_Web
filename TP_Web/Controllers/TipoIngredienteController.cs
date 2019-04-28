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
    public class TipoIngredienteController : Controller
    {
        private ITipoIngredienteService tpingredienteService = new TipoIngredienteService();
        // GET: TipoIngrediente
        public ActionResult Index()
        {
            return View(tpingredienteService.FindAll());
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(TipoIngrediente tpingrediente)
        {
            bool rpta = tpingredienteService.Insert(tpingrediente);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}