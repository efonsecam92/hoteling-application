using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Mantenimientos;
using ENTITIES;

namespace BI.Mantenimientos
{
    public class Companias_BI
    {
        Companias_DAL companiasDal = new Companias_DAL();

        /// <summary>
        /// Método que se encarga de obtener la lista de Companias
        /// </summary>
        /// <returns></returns>
        public List<SGR_Companias> listarCompanias()
        {
            try
            {
                return companiasDal.listarCompanias();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Método que se encarga de agregar un nuevo Compania
        /// </summary>
        /// <param name="compania"></param>
        /// <returns></returns>
        public bool agregarCompania(SGR_Companias compania)
        {
            try
            {
                return companiasDal.agregarCompania(compania);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método que se encarga de obtener la información del Compania en BD
        /// </summary>
        /// <param name="idCompania"></param>
        /// <returns></returns>
        public SGR_Companias obtenerCompaniaDatos(int idCompania)
        {
            try
            {
                return companiasDal.obtenerCompaniaDatos(idCompania);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Método que se encarga de editar la información del Compania
        /// </summary>
        /// <param name="companiaEditar"></param>
        public bool editarCompania(SGR_Companias companiaEditar)
        {
            try
            {
                return companiasDal.editarCompania(companiaEditar);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Método que se encarga de eliminar un Compania
        /// </summary>
        /// <param name="idCompania"></param>
        /// <returns></returns>
        public bool eliminarCompania(int idCompania)
        {
            try
            {
                return companiasDal.eliminarCompania(idCompania);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
