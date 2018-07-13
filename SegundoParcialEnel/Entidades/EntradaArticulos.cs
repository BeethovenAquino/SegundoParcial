using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.Entidades
{
   public class EntradaArticulos
    {
        [Key]
        public int EntradaID { get; set; }
        public DateTime Fecha { get; set; }
        public string Articulo { get; set; }
        public int Cantidad { get; set; }
        public int ArticuloID { get; set; }


        public EntradaArticulos()
        {
        }
        public override string ToString()
        {
            return this.Articulo;
        }
    }
}
