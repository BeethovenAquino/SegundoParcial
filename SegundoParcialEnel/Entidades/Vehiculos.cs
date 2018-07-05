using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.Entidades
{
    public class Vehiculos
    {
        [Key]
        public int VehiculoID { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int TotalMantenimiento { get; set; }

        public Vehiculos()
        {

        }
    }
}
