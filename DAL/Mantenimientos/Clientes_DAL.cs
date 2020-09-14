using ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Mantenimientos
{
    public class Clientes_DAL
    {
        /// <summary>
        /// Método que se encarga de obtener la lista de Clientes
        /// </summary>
        /// <returns></returns>
        public List<SGR_Clientes> listarClientes()
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    return contexto.SGR_Clientes.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Método que se encarga de agregar un nuevo Cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public bool agregarCliente(SGR_Clientes cliente)
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    contexto.SGR_Clientes.Add(cliente);
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
        /// Método que se encarga de obtener la información del Cliente en BD
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public SGR_Clientes obtenerClienteDatos(int idCliente)
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    return contexto.SGR_Clientes.Where(x => x.ID_Cliente == idCliente).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Método que se encarga de editar la información del Cliente
        /// </summary>
        /// <param name="clienteEditar"></param>
        public bool editarCliente(SGR_Clientes clienteEditar)
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    contexto.Entry(clienteEditar).State = System.Data.Entity.EntityState.Modified;
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
        /// Método que se encarga de eliminar un Cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public bool eliminarCliente(int idCliente)
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    contexto.SGR_Clientes.Remove(contexto.SGR_Clientes.Where(x => x.ID_Cliente == idCliente).FirstOrDefault());
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