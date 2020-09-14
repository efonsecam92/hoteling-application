using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Mantenimientos;
using ENTITIES;

namespace BI.Mantenimientos
{
    public class Usuarios_BI
    {
        Usuarios_DAL usuariosDal = new Usuarios_DAL();

        /// <summary>
        /// Método que se encarga de obtener la lista de usuarios
        /// </summary>
        /// <returns></returns>
        public List<SGR_Usuarios> listarUsuarios()
        {
            try
            {
                return usuariosDal.listarUsuarios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Método que se encarga de agregar un nuevo usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool agregarUsuario(SGR_Usuarios usuario)
        {
            try
            {
                return usuariosDal.agregarUsuario(usuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método que se encarga de obtener la información del usuario en BD
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public SGR_Usuarios obtenerUsuarioDatos(int idUsuario)
        {
            try
            {
                return usuariosDal.obtenerUsuarioDatos(idUsuario);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Método que se encarga de editar la información del usuario
        /// </summary>
        /// <param name="usuarioEditar"></param>
        public bool editarUsuario(SGR_Usuarios usuarioEditar)
        {
            try
            {
                return usuariosDal.editarUsuario(usuarioEditar);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Método que se encarga de eliminar un usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public bool eliminarUsuario(int idUsuario)
        {
            try
            {
                return usuariosDal.eliminarUsuario(idUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método que se encarga de obtener la compañia seleccionada
        /// </summary>
        /// <param name="idCompañia"></param>
        /// <returns></returns>
        public List<SGR_Companias> listarCompaniaSeleccionada(int idCompañia)
        {
            try
            {
                return usuariosDal.listarCompaniaSeleccionada(idCompañia);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
