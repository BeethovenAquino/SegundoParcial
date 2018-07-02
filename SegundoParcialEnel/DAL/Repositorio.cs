using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using static SegundoParcialEnel.DAL.IRepositorio;

namespace SegundoParcialEnel.DAL
{
    public class Repositorio
    {
        public class Repositorio<T> : IDisposable, IRepositorio<T> where T : class
        {
            internal Contexto _contexto;

            public Repositorio(Contexto contexto)
            {
                _contexto = contexto;
            }


            public bool Guardar(T entity)
            {
                bool paso = false;

                try
                {
                    if (_contexto.Set<T>().Add(entity) != null)
                    {
                        _contexto.SaveChanges();
                        paso = true;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return paso;
            }


            public bool Modificar(T entity)
            {
                bool paso = false;
                try
                {
                    _contexto.Entry(entity).State = EntityState.Modified;
                    if (_contexto.SaveChanges() > 0)
                    {
                        paso = true;
                    }
                }
                catch (Exception)
                {
                }
                return paso;
            }
        }
    }
}
