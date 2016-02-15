using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeManager.Entidades;
using HomeManager.Negocio;
using HomeManager.Web.Models;

namespace HomeManager.Web.Controllers
{
    public class ProveedoresController : Controller
    {
        private RepositorioProveedores _repoProveedores = new RepositorioProveedores(new HomeManagerDbContext());

        // GET: /Proveedores/
        public ActionResult Index()
        {
            return View(_repoProveedores.ObtenerTodos().ToList());
        }

        // GET: /Proveedores/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = _repoProveedores.ObtenerPorId(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: /Proveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Proveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nombre,Direccion,Telefono,Ciudad,CodigoPostal")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _repoProveedores.Insertar(proveedor);
                return RedirectToAction("Index");
            }

            return View(proveedor);
        }

        // GET: /Proveedores/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = _repoProveedores.ObtenerPorId(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: /Proveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nombre,Direccion,Telefono,Ciudad,CodigoPostal")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _repoProveedores.Editar(proveedor);
                return RedirectToAction("Index");
            }
            return View(proveedor);
        }

        // GET: /Proveedores/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = _repoProveedores.ObtenerPorId(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: /Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveedor proveedor = _repoProveedores.ObtenerPorId(id);
            _repoProveedores.Eliminar(proveedor);
            return RedirectToAction("Index");
        }
        
    }
}
