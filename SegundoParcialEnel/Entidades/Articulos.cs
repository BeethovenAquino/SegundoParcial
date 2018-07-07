﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.Entidades
{
   public class Articulos
    {
        [Key]
        public int ArticuloID { get; set; }
        public string Descripcion { get; set; }
        public int Costo { get; set; }
        public decimal Precio { get; set; }
        public int Ganancia { get; set; }
        public int Inventario { get; set; }

        public Articulos()
        {
            Ganancia = 0;
        }

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
