using HomeManager.Entidades;
using HomeManager.Negocio.Contratos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeManager.Negocio
{
    public class RepositorioProveedores : RepositorioBase<Proveedor>
    {
        RepositorioProveedores(DbContext db) : base(db) { }
    }
}
