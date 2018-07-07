using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.Entidades
{
   public class MatenimientoDetalle
    {
        [Key]
        public int ID { get; set; }
        public int MantenimientoID { get; set; }
        public int ArticuloID { get; set; }
        public int VehiculoID { get; set; }
        public int TallerID { get; set; }

        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal importe { get; set; }

        public decimal total { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ITBIS { get; set; }

        [ForeignKey("ArticuloID")]
        public virtual Articulos Articulos { get; set; }

        



        public MatenimientoDetalle()
        {
            ID = 0;
            MantenimientoID = 0;

        }

        public MatenimientoDetalle(int iD, int mantenimientoID, int articuloID, int vehiculoID, int tallerID, int cantidad, decimal precio, decimal importe)
        {
            ID = iD;
            MantenimientoID = mantenimientoID;
            ArticuloID = articuloID;
            VehiculoID = vehiculoID;
            TallerID = tallerID;
            Cantidad = cantidad;
            Precio = precio;
            this.importe = importe;
        }
    }
}
