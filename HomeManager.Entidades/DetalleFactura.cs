using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeManager.Entidades
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int FacturaId { get; set; }
        //Navegación
        public Factura Factura { get; set; }
    }
}

//Id,ProductoId,Cantidad,Precio,FacturaId