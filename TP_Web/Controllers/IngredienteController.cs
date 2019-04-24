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
    public class IngredienteController : Controller
    {
        private IIngredienteService ingredienteService = new IngredienteService();
        private ITipoIngredienteService tpingredienteService = new TipoIngredienteService();

        // GET: Ingrediente
        public ActionResult Index()
        {
            return View(ingredienteService.FindAll());
        }

        public ActionResult Create()
        {
            ViewBag.tipoingrediente = tpingredienteService.FindAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Ingrediente ingrdnt)
        {
            ViewBag.tipoingrediente = tpingredienteService.FindAll();
            bool rpta = ingredienteService.Insert(ingrdnt);
            if (rpta)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}