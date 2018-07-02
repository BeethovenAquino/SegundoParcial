using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SegundoParcialEnel.DAL
{
    class Contexto : DbContext
    {
        public DbSet<>  { get; set; }
        public DbSet<>  { get; set; }
        public DbSet<>  { get; set; }


        public Contexto() : base("ConStr") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
