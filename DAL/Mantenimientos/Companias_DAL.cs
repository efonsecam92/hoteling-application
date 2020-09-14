using ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Mantenimientos
{
    public class Companias_DAL
    {
        /// <summary>
        /// Método que se encarga de obtener la lista de Companias
        /// </summary>
        /// <returns></returns>
        public List<SGR_Companias> listarCompanias()
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    return contexto.SGR_Companias.ToList();
                }
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
                using (SGREntities contexto = new SGREntities())
                {
                    contexto.SGR_Companias.Add(compania);
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
        /// Método que se encarga de obtener la información del Compania en BD
        /// </summary>
        /// <param name="idCompania"></param>
        /// <returns></returns>
        public SGR_Companias obtenerCompaniaDatos(int idCompania)
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    return contexto.SGR_Companias.Where(x => x.ID_Compania == idCompania).FirstOrDefault();
                }
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
                using (SGREntities contexto = new SGREntities())
                {
                    contexto.Entry(companiaEditar).State = System.Data.Entity.EntityState.Modified;
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
        /// Método que se encarga de eliminar un Compania
        /// </summary>
        /// <param name="idCompania"></param>
        /// <returns></returns>
        public bool eliminarCompania(int idCompania)
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    contexto.SGR_Companias.Remove(contexto.SGR_Companias.Where(x => x.ID_Compania == idCompania).FirstOrDefault());
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
