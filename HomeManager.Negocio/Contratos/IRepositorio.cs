using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeManager.Negocio.Contratos
{
    public interface IRepositorio<T>
    {
        T ObtenerPorId(int id);
        IQueryable<T> ObtenerTodos();
        IQueryable<T> Filtar(Expression<Func<T, bool>> expresion);
        void Editar(T entidad);
        void Insertar(T entidad);
        void Eliminar(T entidad);
        void EliminarPorId(int id);
        bool GuardarCambios();
    }
}
