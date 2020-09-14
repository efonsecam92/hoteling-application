using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Mantenimientos;
using ENTITIES;

namespace BI.Mantenimientos
{
    public class Clientes_BI
    {
        Clientes_DAL clientesDal = new Clientes_DAL();

        /// <summary>
        /// Método que se encarga de obtener la lista de Clientes
        /// </summary>
        /// <returns></returns>
        public List<SGR_Clientes> listarClientes()
        {
            try
            {
                return clientesDal.listarClientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Método que se encarga de agregar un nuevo cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public bool agregarCliente(SGR_Clientes cliente)
        {
            try
            {
                return clientesDal.agregarCliente(cliente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método que se encarga de obtener la información del cliente en BD
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public SGR_Clientes obtenerClienteDatos(int idCliente)
        {
            try
            {
                return clientesDal.obtenerClienteDatos(idCliente);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Método que se encarga de editar la información del cliente
        /// </summary>
        /// <param name="clienteEditar"></param>
        public bool editarCliente(SGR_Clientes clienteEditar)
        {
            try
            {
                return clientesDal.editarCliente(clienteEditar);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Método que se encarga de eliminar un cliente
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public bool eliminarCliente(int idCliente)
        {
            try
            {
                return clientesDal.eliminarCliente(idCliente);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}