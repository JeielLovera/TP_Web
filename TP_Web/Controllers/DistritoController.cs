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
    public class DistritoController : Controller
    {
        private IDistritoService distritoService = new DistritoService();

        // GET: Distrito
        public ActionResult Index()
        {
            return View(distritoService.FindAll());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Distrito distrito)
        {
            bool rpta = distritoService.Insert(distrito);
            if (rpta) { return RedirectToAction("Index"); }
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Distrito distrito = distritoService.FindById(id);
            return View(distrito);
        }

    }



}