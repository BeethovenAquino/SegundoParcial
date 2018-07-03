﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.Entidades
{
   public class MatenimientoDetalle
    {
        [Key]
        public string Cervicio { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int importe { get; set; }
        public int total { get; set; }

        public virtual ICollection<MatenimientoDetalle> Detalle { get; set; }


        public MatenimientoDetalle()
        {
            this.Detalle = new List<MatenimientoDetalle>();

        }


       
    }
}
