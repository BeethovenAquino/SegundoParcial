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
        public decimal TotalMantenimiento { get; set; }

        public Vehiculos()
        {
            VehiculoID = 0;
            Descripcion = string.Empty;
            TotalMantenimiento = 0;

        }
    }
}
