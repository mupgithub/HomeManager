using HomeManager.Entidades;
using HomeManager.Negocio;
using HomeManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HomeManager.Web.Controllers
{
    //[Authorize]
    public class ProductosController : Controller
    {
        private RepositorioProductos _repoProductos = new RepositorioProductos(new HomeManagerDbContext());
        private RepositorioCategorias _repoCategorias = new RepositorioCategorias(new HomeManagerDbContext());

        // GET: /Productos/
        public ActionResult Index()
        {
            return View(_repoProductos.ObtenerTodos().ToList());
        }

        public ActionResult CrearProducto()
        {
            ViewBag.CategoriaId = new SelectList(_repoCategorias.ObtenerTodos().ToList(), "Id", "Nombre");
            return PartialView("_CrearProducto");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearProducto(Producto NuevoProducto)
        {
            if (ModelState.IsValid)
            {
                _repoProductos.Insertar(NuevoProducto);
                if (_repoProductos.GuardarCambios()) 
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CategoriaId = new SelectList(_repoCategorias.ObtenerTodos().ToList(), "Id", "Nombre", NuevoProducto.CategoriaId);
            //Mostrar error
            return View();
        }

        // GET: Productos/Editar/5
        public ActionResult Editar(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Producto producto = _repoProductos.ObtenerPorId(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(_repoCategorias.ObtenerTodos().ToList(), "Id", "Nombre", producto.CategoriaId);
            return View(producto);
        }

        // POST: Productos/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,Codigo,Descripcion,UltimoPrecio,CategoriaId")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _repoProductos.Editar(producto);
                if (_repoProductos.GuardarCambios())
                {
                    return RedirectToAction("Index");
                }
             }
            ViewBag.CategoriaId = new SelectList(_repoCategorias.ObtenerTodos().ToList(), "Id", "Nombre", producto.CategoriaId);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public ActionResult Eliminar(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Producto producto = _repoProductos.ObtenerPorId(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EmiminacionConfirmada(int id)
        {
            Producto producto = _repoProductos.ObtenerPorId(id);
            _repoProductos.Eliminar(producto);
            _repoProductos.GuardarCambios();
            return RedirectToAction("Index");
        }

	}
}