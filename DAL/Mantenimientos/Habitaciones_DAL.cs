using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITIES;

namespace DAL.Mantenimientos
{
    public class Habitaciones_DAL
    {
        /// <summary>
        /// Método que se encarga de obtener la lista de habitaciones
        /// </summary>
        /// <returns></returns>
        public List<SGR_Habitaciones> listarHabitaciones()
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    return contexto.SGR_Habitaciones.OrderBy(x => x.Numero).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que se encarga de agregar una habitación a BD
        /// </summary>
        /// <param name="habitacion"></param>
        /// <returns></returns>
        public bool agregarHabitacion(SGR_Habitaciones habitacion)
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    contexto.SGR_Habitaciones.Add(habitacion);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Método encargado de obtener los datos de la habitación seleccionada
        /// </summary>
        /// <param name="idHabitacion"></param>
        /// <returns></returns>
        public SGR_Habitaciones obtenerHabitacionDatos(int idHabitacion)
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    return contexto.SGR_Habitaciones.Where(x => x.ID_Habitacion == idHabitacion).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Método que se encarga de eliminar una habitación de BD
        /// </summary>
        /// <param name="idHabitacion"></param>
        /// <returns></returns>
        public bool eliminarHabitacion(int idHabitacion)
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    contexto.SGR_Habitaciones.Remove(contexto.SGR_Habitaciones.Where(x => x.ID_Habitacion == idHabitacion).FirstOrDefault());
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Método que se encarga de editar una habitación
        /// </summary>
        /// <param name="habitacionEditar"></param>
        /// <returns></returns>
        public bool editarHabitacion(SGR_Habitaciones habitacionEditar)
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    contexto.Entry(habitacionEditar).State = System.Data.Entity.EntityState.Modified;
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
