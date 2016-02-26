using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HomeManager.Entidades
{
    public class Proveedor
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        [MinLength(5)]
        public string CodigoPostal { get; set; }
        //Navegación
        public ICollection<Factura> Facturas { get; set; }
    }
}
