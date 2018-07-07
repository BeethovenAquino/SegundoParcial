using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.Entidades
{
    public class Taller
    {
        [Key]
        public int TallerID { get; set; }
        public string Nombre { get; set; }

        public Taller()
        {
            TallerID = 0;
            Nombre = string.Empty;
        }
        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
