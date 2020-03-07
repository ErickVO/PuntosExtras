using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Personas.Entidades;

namespace Personas.DAL
{
   public class Contexto : DbContext
    {
        public DbSet<Persona> Persona { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Persona.db");
        }
    }
}
