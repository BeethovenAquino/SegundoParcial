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
   public class MantenimientoBLL
    {
        public static bool Guardar(Mantenimiento mantenimiento)
        {
            bool paso = false;
            Contexto contexto = new Contexto();


            Vehiculos vehiculos = new Vehiculos();
            try
            {
                if (contexto.Mantenimiento.Add(mantenimiento) != null)
                {

                    foreach (var item in mantenimiento.Detalle)
                    {
                        contexto.Articulos.Find(item.ArticulosID).Inventario -= item.Cantidad;
                    }


                    contexto.Vehiculo.Find(mantenimiento.VehiculoID).TotalMantenimiento += mantenimiento.Total;

                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Mantenimiento mantenimiento = contexto.Mantenimiento.Find(id);

                foreach (var item in mantenimiento.Detalle)
                {
                    var articulo = contexto.Articulos.Find(item.ArticulosID);
                    articulo.Inventario += item.Cantidad;
                }

                contexto.Mantenimiento.Remove(mantenimiento);

                contexto.Vehiculo.Find(mantenimiento.VehiculoID).TotalMantenimiento -= mantenimiento.Total;

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

        public static Mantenimiento Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Mantenimiento mantenimiento = new Mantenimiento();
            try
            {
                mantenimiento = contexto.Mantenimiento.Find(id);
                if (mantenimiento != null)
                {
                    //Cargar la lista en este punto porque
                    //luego de hacer Dispose() el Contexto 
                    //no sera posible leer la lista
                    mantenimiento.Detalle.Count();

                    //Cargar los nombres de las ciudades
                    foreach (var item in mantenimiento.Detalle)
                    {
                        //forzando la ciudad a cargarse
                        string s = item.Articulos.Descripcion;
                    }

                    contexto.Dispose();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return mantenimiento;
        }



    

             public static List<Mantenimiento> GetList(Expression<Func<Mantenimiento, bool>> expression)
            {
                List<Mantenimiento> mantenimientos = new List<Mantenimiento>();
                Contexto contexto = new Contexto();
                try
                {
                    mantenimientos = contexto.Mantenimiento.Where(expression).ToList();
                    contexto.Dispose();
                }
                catch (Exception)
                {

                    throw;
                }

                return mantenimientos;
            }

        public static bool Modificar(Mantenimiento mantenimiento)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //todo: buscar las entidades que no estan para removerlas
                var visitaant = MantenimientoBLL.Buscar(mantenimiento.MantenimientoID);

                foreach (var item in visitaant.Detalle)//recorrer el detalle aterior
                {
                    //restar todas las visitas
                    contexto.Articulos.Find(item.ArticulosID).Inventario += item.Cantidad;

                    //determinar si el item no esta en el detalle actual
                    if (!mantenimiento.Detalle.ToList().Exists(v => v.ID == item.ID))
                    {
                     //   contexto.Articulos.Find(item.ArticulosID).Inventario -= item.Cantidad;
                        item.Articulos = null; //quitar la ciudad para que EF no intente hacerle nada
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                //recorrer el detalle
                foreach (var item in mantenimiento.Detalle)
                {
                    //Sumar todas las visitas
                    contexto.Articulos.Find(item.ArticulosID).Inventario -= item.Cantidad;

                    //Muy importante indicar que pasara con la entidad del detalle
                    var estado = item.ID > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

               Mantenimiento EntradaAnterior = BLL.MantenimientoBLL.Buscar(mantenimiento.MantenimientoID);


                //identificar la diferencia ya sea restada o sumada
                decimal diferencia;

                diferencia = mantenimiento.Total - EntradaAnterior.Total;

                //aplicar diferencia al inventario
                Vehiculos vehiculos = BLL.VehiculosBLL.Buscar(mantenimiento.VehiculoID);
                vehiculos.TotalMantenimiento += diferencia;
                BLL.VehiculosBLL.Modificar(vehiculos);


                //Idicar que se esta modificando el encabezado
                contexto.Entry(mantenimiento).State = EntityState.Modified;

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

        public static decimal CalcularImporte(decimal precio, int cantidad)
        {
            return Convert.ToDecimal(precio) * Convert.ToInt32(cantidad);
        }



    }
}
