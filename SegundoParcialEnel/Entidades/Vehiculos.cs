using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.Entidades
{
    class Vehiculos
    {
        [Key]
        public int VehiculoID { get; set; }
        public string Descripcion { get; set; }
        public int Mantenimiento { get; set; }

        public Vehiculos()
        {

        }
    }
}
