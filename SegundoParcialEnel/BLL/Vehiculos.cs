using SegundoParcialEnel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SegundoParcialEnel.BLL
{
   public  class Vehiculos
    {
        public static List<Vehiculos> GetList(Expression<Func<Vehiculos, bool>>expression)
        {
            List<Vehiculos> vehiculos = new List<Vehiculos>();
            Contexto contexto = new Contexto();

        }
    }
}
