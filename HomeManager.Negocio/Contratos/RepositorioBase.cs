using HomeManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeManager.Negocio.Contratos
{
    public abstract class RepositorioBase<T> : IRepositorio<T> where T:class
    {
        public DbContext _context;
        public DbSet<T> _dbset;
        public RepositorioBase(DbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public T ObtenerPorId(int id)
        {
            return _dbset.Find(id);
        }
        
        public IQueryable<T> ObtenerTodos()
        {
            return _dbset;
        }

        public void Insertar(T entidad)
        {
            _dbset.Add(entidad);
        }


        public void Editar(T entidad)
        {
            _context.Entry(entidad).State = EntityState.Modified;
        }
        
        public void Eliminar(T entidad)
        {
            _context.Entry(entidad).State = EntityState.Deleted;
        }

        public IQueryable<T> Filtar(Expression<Func<T, bool>> expresion)
        {
            return _dbset.Where(expresion);
        }

        public void EliminarPorId(int id)
        {
            T entidad = _dbset.Find(id);
            _context.Entry(entidad).State = EntityState.Deleted;
        }
    }
}
