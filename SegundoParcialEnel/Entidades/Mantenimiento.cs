using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.Entidades
{
    class Mantenimiento
    {
        [Key]
        public int MantenimientoID { get; set; }
        public DateTime Fecha { get; set; }
        public string Vehiculo { get; set; }
        public string Taller { get; set; }

        public Mantenimiento(int mantenimientoID, DateTime fecha, string vehiculo, string taller)
        {
            MantenimientoID = mantenimientoID;
            Fecha = fecha;
            Vehiculo = vehiculo;
            Taller = taller;
        }
    }
}
