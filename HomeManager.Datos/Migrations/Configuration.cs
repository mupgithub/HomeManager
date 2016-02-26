namespace HomeManager.Web.Migrations
{
    using HomeManager.Entidades;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeManager.Web.Models.HomeManagerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HomeManager.Web.Models.HomeManagerDbContext context)
        {
            context.Categorias.AddOrUpdate(c => c.Nombre,
                new Categoria { Nombre = "Alimentos" },
                new Categoria { Nombre = "Ropa" });
            context.SaveChanges();
            context.Productos.AddOrUpdate(
                new Producto { Codigo = "LECHEERIA", Descripcion = "Leche Entera Eria 1L", UltimoPrecio = (decimal)0.58, CategoriaId = 1 },
                new Producto { Codigo = "QHUNTAR", Descripcion = "Queso Blanco para huntar", UltimoPrecio = (decimal)1, CategoriaId = 1 },
                new Producto { Codigo = "PIZZAQUESO", Descripcion = "Pizza de Queso y Tomate", UltimoPrecio = (decimal)1.8, CategoriaId = 1 });
            context.SaveChanges();
            context.Proveedores.AddOrUpdate(
                new Proveedor { Nombre = "Mercadona", Direccion = "Amos de Escalante", Ciudad = "Madrid", CodigoPostal = "28017" },
                new Proveedor { Nombre = "AhorraMas", Direccion = "Hermanos García Nobleja", Ciudad = "Madrid", CodigoPostal = "28017" });
            context.SaveChanges();
        }
    }
}
