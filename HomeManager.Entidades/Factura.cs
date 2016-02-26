using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeManager.Entidades
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        public int ProveedorId { get; set; }
        //Navegación
        virtual public Proveedor Proveedor { get; set; }
        virtual public ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
