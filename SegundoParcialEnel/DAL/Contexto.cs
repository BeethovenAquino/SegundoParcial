using SegundoParcialEnel.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Mantenimiento> Mantenimiento { get; set; }
        public DbSet<Vehiculos>  Vehiculo{ get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Taller> Taller { get; set; }
        public DbSet<EntradaArticulos> EntradaArticulos { get; set; }

        public Contexto() : base("ConStr") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
