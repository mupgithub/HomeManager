using HomeManager.Entidades;
using HomeManager.Negocio;
using HomeManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeManager.Web.Controllers
{
    public class FacturasController : Controller
    {
        private RepositorioProveedores _repoProveedores = new RepositorioProveedores(new HomeManagerDbContext());
        private RepositorioFacturas _repoFacturas = new RepositorioFacturas(new HomeManagerDbContext());

        //
        // GET: /Facturas/
        public ActionResult Index()
        {
            return View(_repoFacturas.ObtenerTodos().ToList());
        }

        //
        // GET: /Facturas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Facturas/Create
        public ActionResult Create()
        {
            ViewBag.ProveedorId = new SelectList(_repoProveedores.ObtenerTodos().ToList(), "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fecha, ProveedorId")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _repoFacturas.Insertar(factura);
                _repoFacturas.GuardarCambios();

                return RedirectToAction("Edit", new { controller = "Facturas", action = "Edit", Id = factura.Id });
            }

           ViewBag.ProveedorId = new SelectList(_repoProveedores.ObtenerTodos().ToList(), "Id", "Nombre",factura.Id);
            return View(factura);
        }

        //
        // GET: /Facturas/Edit/5
        public ActionResult Edit(int id)
        {
            Factura factura = _repoFacturas.ObtenerPorId(id);
            if (factura == null)
            {
                return HttpNotFound();
            }

            return View(factura);
        }

        //
        // POST: /Facturas/Edit/5
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

        // GET: /Facturas/
        public ActionResult Detalles()
        {
            return View();
        }



        //
        // GET: /Facturas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Facturas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
