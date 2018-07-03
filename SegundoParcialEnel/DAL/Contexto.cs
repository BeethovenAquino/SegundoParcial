using SegundoParcialEnel.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Mantenimiento> mantenimientos { get; set; }
        public DbSet<Vehiculos>  Vehiculo{ get; set; }
        public DbSet<MatenimientoDetalle> mantenimientoDetalle{ get; set; }

        


        public Contexto() : base("ConStr") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
