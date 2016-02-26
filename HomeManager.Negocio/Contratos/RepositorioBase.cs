using HomeManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeManager.Negocio.Contratos
{
    public abstract class RepositorioBase<T> : IRepositorio<T> where T:class
    {
        private DbContext _context;
        private DbSet<T> _dbset;
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


        public bool GuardarCambios()
        {
            try
            {

                return _context.SaveChanges()>0;
            }
            catch (Exception e)
            {
                //Tratar Error
                Debug.WriteLine(String.Format("Error No. {0} : {1}", e.HResult.ToString(), e.Message));
                return false;
            }
        }
    }
}
