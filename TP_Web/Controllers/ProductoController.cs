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
    public class ProductoController : Controller
    {
        private IProductoService productoService = new ProductoService();
        // GET: Producto
        public ActionResult Index()
        {        
           
            return View(productoService.FindAll());
        }
    }
}