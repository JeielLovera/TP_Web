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
    public class ClienteController : Controller
    {
        private IClienteService clienteservice = new ClienteService();
        private IDireccionService direccionservice = new DireccionService();
        // GET: Cliente
        public ActionResult Index()
        {
            return View(clienteservice.FindAll());
        }

        public ActionResult Create()
        {
            ViewBag.direccion = direccionservice.FindAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            ViewBag.direccion = direccionservice.FindAll();
            bool rpta = clienteservice.Insert(cliente);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}