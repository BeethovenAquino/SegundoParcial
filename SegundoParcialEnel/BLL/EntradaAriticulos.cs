﻿using SegundoParcialEnel.DAL;
using SegundoParcialEnel.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SegundoParcialEnel.BLL
{
   public class EntradaAriticulos
    {
        public static bool Guardar(EntradaArticulos entradaAriticulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.EntradaArticulos.Add(entradaAriticulos) != null)
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

        public static bool Modificar(EntradaArticulos entradaAriticulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(entradaAriticulos).State = EntityState.Modified;
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
                EntradaArticulos entradaAriticulos = contexto.EntradaArticulos.Find(id);

                if (entradaAriticulos != null)
                {
                    contexto.Entry(entradaAriticulos).State = EntityState.Deleted;
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

        public static EntradaArticulos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            EntradaArticulos entradaAriticulos = new EntradaArticulos();
            try
            {
                entradaAriticulos = contexto.EntradaArticulos.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return entradaAriticulos;
        }

        public static List<EntradaArticulos> GetList(Expression<Func<EntradaArticulos, bool>> expression)
        {
            List<EntradaArticulos> entradaAriticulos = new List<EntradaArticulos>();
            Contexto contexto = new Contexto();
            try
            {
                entradaAriticulos = contexto.EntradaArticulos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return entradaAriticulos;
        }

        public static string RetornarArticulo(string Articulo)
        {
            string articulo = string.Empty;
            var lista = GetList(x => x.Articulo.Equals(Articulo));
            foreach (var item in lista)
            {
                articulo = item.Articulo;
            }

            return Articulo;
        }
    }
}