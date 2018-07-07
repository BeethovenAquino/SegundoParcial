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
        public DateTime Fecha { get; set; }
 

        public virtual ICollection<MatenimientoDetalle> Detalle { get; set; }


        public Mantenimiento()
        {
            this.Detalle = new List<MatenimientoDetalle>();
            

        }

        public Mantenimiento(int mantenimientoID, DateTime fecha)
        {
            MantenimientoID = mantenimientoID;
            Fecha = fecha;
  
        }

        public void agregarDetalle(int iD, int mantenimientoID, int articuloID, int vehiculoID, int tallerID, int cantidad, decimal precio, decimal importe) {
            this.Detalle.Add(new MatenimientoDetalle( iD, mantenimientoID, articuloID,vehiculoID, tallerID, cantidad,precio,importe));
        }
    }
}
