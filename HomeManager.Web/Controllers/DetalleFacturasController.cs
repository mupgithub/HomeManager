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
    public class DetalleFacturasController : Controller
    {
        private RepositorioDetalleFacturas _repoDetalles = new RepositorioDetalleFacturas(new HomeManagerDbContext());
        private RepositorioFacturas _repoFacturas = new RepositorioFacturas(new HomeManagerDbContext());
        private RepositorioProductos _repoProductos = new RepositorioProductos(new HomeManagerDbContext());

        public ActionResult Index(int FacturaId)
        {
            ViewBag.FacturaId = FacturaId;
            var detalles = _repoDetalles.ObtenerTodos()
                .Where(d => d.FacturaId == FacturaId)
                .OrderBy(d => d.ProductoId);

            return PartialView("_index", detalles.ToList());
        }


        public ActionResult Create(int FacturaId)
        {
            DetalleFactura detalle = new DetalleFactura();
            detalle.FacturaId = FacturaId;
            ViewBag.ProductoId = new SelectList(_repoProductos.ObtenerTodos().ToList(), "Id", "Descripcion");
            return PartialView("_Create", detalle);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, ProductoId, Cantidad, Precio, FacturaId")] DetalleFactura detalle)
        {
            if (ModelState.IsValid)
            {
                _repoDetalles.Insertar(detalle);
                _repoDetalles.GuardarCambios();
            }

            return PartialView("_Create", detalle);
        }
    }
}