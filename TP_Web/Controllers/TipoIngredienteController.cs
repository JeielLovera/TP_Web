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

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            TipoIngrediente tpingrediente = tpingredienteService.FindById(id);
            return View(tpingrediente);
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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            TipoIngrediente tpingrediente = tpingredienteService.FindById(id);
            return View(tpingrediente);
        }

        [HttpPost]
        public ActionResult Edit(TipoIngrediente tpingrediente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = tpingredienteService.Update(tpingrediente);
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
            TipoIngrediente tpingrediente = tpingredienteService.FindById(id);
            return View(tpingrediente);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = tpingredienteService.Delete(id);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}