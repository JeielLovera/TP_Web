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
    public class Orden_ProductoPersonalizadoController : Controller
    {
        // GET: Orden_Producto_Personalizado

        private IOrden_ProductoPersonalizadoService orden_ProductoPersonalizadoService = new Orden_ProductoPersonalizadoService();

        private IOrdenService ordenService = new OrdenService();
        private IIngredienteService ingredienteService = new IngredienteService();
        private IEmpleadoService empleadoService = new EmpleadoService();

        public ActionResult Index()
        {

            return View(orden_ProductoPersonalizadoService.FindAll());
        }

        // GET: Orden_Producto_Personalizado/Create
        public ActionResult Create()
        {
            ViewBag.orden = ordenService.FindAll();
            ViewBag.ingrediente = ingredienteService.FindAll();
            ViewBag.empleado = empleadoService.FindAll();
            return View();
        }

        // POST: Orden_Producto_Personalizado/Create
        [HttpPost]
        public ActionResult Create(Orden_ProductoPersonalizado orden_ProductoPersonalizado)
        {

            ViewBag.orden = ordenService.FindAll();
            ViewBag.ingrediente = ingredienteService.FindAll();
            ViewBag.empleado = empleadoService.FindAll();

            bool rpta = orden_ProductoPersonalizadoService.Insert(orden_ProductoPersonalizado);
            if (rpta)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Orden_Producto_Personalizado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orden_Producto_Personalizado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
