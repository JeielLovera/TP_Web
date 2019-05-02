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
    public class VentaController : Controller
    {
        private IVentaService ventaservice = new VentaService();
        private ILocalService localservice = new LocalService();
        private IEmpleadoService motorizadoservice = new EmpleadoService();
        private IClienteService clienteservice = new ClienteService();
        // GET: Venta
        public ActionResult Index()
        {
            return View(ventaservice.FindAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Venta venta = ventaservice.FindById(id);
            return View(venta);
        }

        public ActionResult Create()
        {
            ViewBag.local = localservice.FindAll();
            ViewBag.motorizado = motorizadoservice.FindAll();
            ViewBag.cliente = clienteservice.FindAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Venta venta)
        {
            ViewBag.local = localservice.FindAll();
            ViewBag.motorizado = motorizadoservice.FindAll();
            ViewBag.cliente = clienteservice.FindAll();
            bool rpta = ventaservice.Insert(venta);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.local = localservice.FindAll();
            ViewBag.motorizado = motorizadoservice.FindAll();
            ViewBag.cliente = clienteservice.FindAll();

            if (id == null)
            {
                return HttpNotFound();
            }
            Venta venta = ventaservice.FindById(id);
            return View(venta);
        }
        [HttpPost]
        public ActionResult Edit(Venta venta)
        {
            ViewBag.local = localservice.FindAll();
            ViewBag.motorizado = motorizadoservice.FindAll();
            ViewBag.cliente = clienteservice.FindAll();
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = ventaservice.Update(venta);
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
            Venta venta = ventaservice.FindById(id);
            return View(venta);
       }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = ventaservice.Delete(id);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}