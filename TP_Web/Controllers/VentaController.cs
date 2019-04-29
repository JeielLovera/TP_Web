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
            if(rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}