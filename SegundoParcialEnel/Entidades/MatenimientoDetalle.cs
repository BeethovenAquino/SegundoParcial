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
        public int TallerID { get; set; }
        public int ArticulosID { get; set; }
        public string Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        [ForeignKey("ArticulosID")]
        public virtual Articulos Articulos { get; set; }

        public MatenimientoDetalle()
        {
            ID = 0;
            MantenimientoID = 0;
        }

        public MatenimientoDetalle(int id, int mantenimientoId, int tallerId, int articulosId, string articulo,int cantidad,decimal precio, decimal importe)
        {
            ID = id;
            MantenimientoID= mantenimientoId;

            TallerID = tallerId;
            ArticulosID = articulosId;

            Articulo = articulo;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }



        public MatenimientoDetalle(int mantenimientoId, int articulosId, string articulo, int cantidad, int precio, int importe)
        {

            MantenimientoID = mantenimientoId;
            ArticulosID = articulosId;
            Articulo = articulo;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
