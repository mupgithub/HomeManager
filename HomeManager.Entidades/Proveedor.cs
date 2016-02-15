using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeManager.Entidades
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        //Navegación
        public List<Factura> Facturas { get; set; }
    }
}
