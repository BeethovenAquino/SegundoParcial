using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.Entidades
{
   public class Articulos
    {
        public int ArticuloID { get; set; }
        public string Descripcion { get; set; }
        public int Costo { get; set; }
        public int Precio { get; set; }
        public int Ganancia { get; set; }
        public string Inventario { get; set; }

        public Articulos()
        {
        }

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
