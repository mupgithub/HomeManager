using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeManager.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        //Navegación
        virtual public ICollection<Producto> Productos { get; set; }
    }
}
