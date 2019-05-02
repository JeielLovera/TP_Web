﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Business.Implementation;
using Entity;

namespace TP_PIZZA.Controllers
{
    public class OrdenController : Controller
    {
        // GET: Orden
        private IOrdenService ordenService = new OrdenService();
        private IVentaService ventaService = new VentaService();

        public ActionResult Index()
        {
            return View(ordenService.FindAll());
        }
        // GET: Orden/Create
        public ActionResult Create()
        {
            ViewBag.ventaservice = ventaService.FindAll();
            return View();
        }

        // POST: Orden/Create
        [HttpPost]
        public ActionResult Create(Orden orden)
        {
            ViewBag.ventaservice = ventaService.FindAll();
            bool rpta = ordenService.Insert(orden);
            if (rpta)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Orden/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ventaservice = ventaService.FindAll();
            if (id == null) { return HttpNotFound(); }            
            Orden orden = ordenService.FindById(id);
            return View(orden);
        }

        // POST: Orden/Edit/5
        [HttpPost]
        public ActionResult Edit( Orden orden)
        {
            ViewBag.ventaservice = ventaService.FindAll();
            if (!ModelState.IsValid) { return View(); }
            bool rpta = ordenService.Update(orden);
            if (rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int?id)
        {
            if(id==null)
            {
                return HttpNotFound();
            }
            Orden orden = ordenService.FindById(id);
            return View(orden);
        }
        public ActionResult Delete(int? id)
        {
            if(id==null)
            {
                return HttpNotFound();
            }
            Orden orden = ordenService.FindById(id);
            return View(orden);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = ordenService.Delete(id);
            if(rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
