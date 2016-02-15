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
    class RepositorioDetalleFacturas : RepositorioBase<DetalleFactura>
    {
        public RepositorioDetalleFacturas(DbContext db) : base(db) { }
    }
}
