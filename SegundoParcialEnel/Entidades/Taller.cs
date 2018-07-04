using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.Entidades
{
    public class Taller
    {
        public int TallerID { get; set; }
        public string Nombre { get; set; }

        public Taller()
        {
        }
        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
