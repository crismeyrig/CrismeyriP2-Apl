using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrismeyriP2_Apl.DAL;
using CrismeyriP2_Apl.Entidades;

namespace CrismeyriP2_Apl.BLL
{
    public class TareasBLL
    {
          public static List<Tareas> GetTareas()
        {
            List<Tareas> tareas = new List<Tareas>();
            Contexto contexto = new Contexto();

            try
            {
                tareas = contexto.Tareas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tareas;
        }
    }
}