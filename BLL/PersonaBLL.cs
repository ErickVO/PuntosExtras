using Microsoft.EntityFrameworkCore;
using Personas.DAL;
using Personas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Personas.BLL
{
    public class PersonaBLL
    {
        public static bool Guardar(Persona persona)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if(db.Persona.Add(persona) != null)
                {
                    paso = (db.SaveChanges() > 0);
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Persona persona)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Entry(persona).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);   
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var eliminar = db.Persona.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);

            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Persona Buscar(int id)
        {
            Contexto db = new Contexto();
            Persona persona = new Persona();

            try
            {
                persona = db.Persona.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return persona;
        }

        public static List<Persona> GetList(Expression<Func<Persona,bool>> persona)
        {
            Contexto db = new Contexto();
            List<Persona> Listado = new List<Persona>();

            try
            {
                Listado = db.Persona.Where(persona).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Listado;
        }
    }
}
