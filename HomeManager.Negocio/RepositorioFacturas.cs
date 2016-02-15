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
    class RepositorioFacturas: RepositorioBase<Factura>
    {
        public RepositorioFacturas(DbContext db) : base(db) { }
    }
}
