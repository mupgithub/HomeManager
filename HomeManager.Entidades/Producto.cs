using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeManager.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal UltimoPrecio { get; set; }
        public int CategoriaId { get; set; }
        //Navegación
        virtual public Categoria Categoria { get; set; }
    }
}
