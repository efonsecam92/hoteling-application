using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Mantenimientos;
using ENTITIES;

namespace BI.Mantenimientos
{
    public class Habitaciones_BI
    {
        Habitaciones_DAL habitacionesDal = new Habitaciones_DAL();

        /// <summary>
        /// Método que se encarga de obtener la lista de habitaciones
        /// </summary>
        /// <returns></returns>
        public List<SGR_Habitaciones> listarHabitaciones()
        {
            try
            {
                return habitacionesDal.listarHabitaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Método que se encarga de agregar una nueva habitación
        /// </summary>
        /// <param name="habitacion"></param>
        /// <returns></returns>
        public bool agregarHabitacion(SGR_Habitaciones habitacion)
        {
            try
            {
                return habitacionesDal.agregarHabitacion(habitacion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método que se encarga de obtener la información de la habitación en BD
        /// </summary>
        /// <param name="idHabitacion"></param>
        /// <returns></returns>
        public SGR_Habitaciones obtenerHabitacionDatos(int idHabitacion)
        {
            try
            {
                return habitacionesDal.obtenerHabitacionDatos(idHabitacion);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Método que se encarga de editar la información de la habitación
        /// </summary>
        /// <param name="habitacionEditar"></param>
        public bool editarHabitacion(SGR_Habitaciones habitacionEditar)
        {
            try
            {
                return habitacionesDal.editarHabitacion(habitacionEditar);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Método que se encarga de eliminar una habitación
        /// </summary>
        /// <param name="idHabitacion"></param>
        /// <returns></returns>
        public bool eliminarHabitacion(int idHabitacion)
        {
            try
            {
                return habitacionesDal.eliminarHabitacion(idHabitacion);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
