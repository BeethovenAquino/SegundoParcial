using SegundoParcialEnel.UI.Regristro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.Entidades
{
   public class Mantenimiento
    {
        [Key]
        public int MantenimientoID { get; set; }
        public int VehiculoID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Subtotal { get; set; }
        public decimal itbis { get; set; }
        public decimal Total { get; set; }


        public virtual ICollection<MatenimientoDetalle> Detalle { get; set; }

        public Mantenimiento()
        {
            this.Detalle = new List<MatenimientoDetalle>();

            MantenimientoID = 0;
            Fecha = DateTime.Now;
            Subtotal = 0;
            itbis = 0;
            Total = 0;

        }



        public void AgregarDetalle(int id, int MantenimientoID, int tallerID, int articulosID,string articulo,  int cantidad, decimal precio, decimal importe)
        {
            this.Detalle.Add(new MatenimientoDetalle(id, MantenimientoID, tallerID, articulosID, articulo, cantidad, precio, importe));
        }
    }
}
