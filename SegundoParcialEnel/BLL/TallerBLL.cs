using SegundoParcialEnel.DAL;
using SegundoParcialEnel.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SegundoParcialEnel.BLL
{
   public class TallerBLL
    {
        public static bool Guardar(Taller taller)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Taller.Add(taller) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static bool Modificar(Taller taller)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(taller).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Taller taller = contexto.Taller.Find(id);

                if (taller != null)
                {
                    contexto.Entry(taller).State = EntityState.Deleted;
                }

                if (contexto.SaveChanges() > 0)
                {
                    contexto.Dispose();
                    paso = true;
                }


            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static Taller Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Taller taller = new Taller();
            try
            {
                taller = contexto.Taller.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return taller;
        }

        public static List<Taller> GetList(Expression<Func<Taller, bool>> expression)
        {
            List<Taller> taller = new List<Taller>();
            Contexto contexto = new Contexto();
            try
            {
                taller = contexto.Taller.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return taller;
        }

        public static string RetornarNombre(string Nombre)
        {
            string nombre = string.Empty;
            var lista = GetList(x => x.Nombre.Equals(Nombre));
            foreach (var item in lista)
            {
                nombre = item.Nombre;
            }

            return nombre;
        }
    }
}
