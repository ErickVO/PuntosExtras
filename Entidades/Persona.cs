using System;
using System.Collections.Generic;
using System.Text;

namespace Personas.Entidades
{
    public class Persona
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }

        public Persona()
        {
            PersonaId = 0;
            Nombre = string.Empty;
        }
    }
}
