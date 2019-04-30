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
    public class Orden_ProductoController : Controller
    {
        // GET: Orden_Producto
        private IOrden_ProductoService orden_ProductoService = new Orden_ProductoService();

        private IOrdenService ordenService = new OrdenService();
        private IProductoService productoService = new ProductoService();
        private IEmpleadoService empleadoService = new EmpleadoService();

        public ActionResult Index()
        {
            return View(orden_ProductoService.FindAll());
        }

        // GET: Orden_Producto/Create
        public ActionResult Create()
        {
            ViewBag.orden = ordenService.FindAll();
            ViewBag.producto = productoService.FindAll();
            ViewBag.empleado = empleadoService.FindAll();
            return View();
        }

        // POST: Orden_Producto/Create
        [HttpPost]
        public ActionResult Create(Orden_Producto orden_Producto)
        {
            ViewBag.orden = ordenService.FindAll();
            ViewBag.producto = productoService.FindAll();
            ViewBag.empleado = empleadoService.FindAll();

            bool rpta = orden_ProductoService.Insert(orden_Producto);
            if (rpta)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        
        public ActionResult Edit(int? id)
        {
            ViewBag.orden = ordenService.FindAll();
            ViewBag.producto = productoService.FindAll();
            ViewBag.empleado = empleadoService.FindAll();
            if(id==null)
            {
                return HttpNotFound();
            }
            Orden_Producto ordenprod = orden_ProductoService.FindById(id);
            return View(ordenprod);
        }
        
        [HttpPost]
        public ActionResult Edit(Orden_Producto ordenprod)
        {
            ViewBag.orden = ordenService.FindAll();
            ViewBag.producto = productoService.FindAll();
            ViewBag.empleado = empleadoService.FindAll();
            if(!ModelState.IsValid)
            {
                return View();
            }
            bool rpta = orden_ProductoService.Update(ordenprod);
            if(rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int? id)
        {
            if(id==null)
            {
                return HttpNotFound();
            }
            Orden_Producto ordenProd = orden_ProductoService.FindById(id);
            return View(ordenProd);
        }
    }
}
