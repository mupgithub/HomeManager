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
    [Authorize]
    public class ProductosController : Controller
    {
        private RepositorioProductos _repoProductos = new RepositorioProductos(new HomeManagerDbContext());
              
        // GET: /Productos/
        public ActionResult Index()
        {
            return View(_repoProductos.ObtenerTodos().ToList());
        }

        public ActionResult CrearProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearProducto(Producto NuevoProducto)
        {
            //ViewData["CategoryID"] = new SelectList(_cRepository.GetAll().ToList(), "Category_id", "Category");
            //IEnumerable<SelectListItem> items = _cRepository.GetAll().Select(c => new SelectListItem
            //{
            //    Value = c.Id.ToString(),
            //    Text = c.Name
            //});

            //ViewData["CategoryID"] = items;
            

            return View();
        }
	}
}