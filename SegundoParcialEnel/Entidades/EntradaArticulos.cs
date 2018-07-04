using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.Entidades
{
   public class EntradaArticulos
    {
        public int EntradaID { get; set; }
        public DateTime Fecha { get; set; }
        public string Articulo { get; set; }
        public int Cantidad { get; set; }

        public EntradaArticulos()
        {
        }
        public override string ToString()
        {
            return this.Articulo;
        }
    }
}
