using ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Mantenimientos
{
    public class Usuarios_DAL
    {
        /// <summary>
        /// Método que se encarga de obtener la lista de usuarios
        /// </summary>
        /// <returns></returns>
        public List<SGR_Usuarios> listarUsuarios()
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    return contexto.SGR_Usuarios.ToList();
                }
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
                using (SGREntities contexto = new SGREntities())
                {
                    contexto.SGR_Usuarios.Add(usuario);
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
        /// Método que se encarga de obtener la información del usuario en BD
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public SGR_Usuarios obtenerUsuarioDatos(int idUsuario)
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    return contexto.SGR_Usuarios.Where(x => x.ID_Usuario == idUsuario).FirstOrDefault();
                }
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
                using (SGREntities contexto = new SGREntities())
                {
                    contexto.Entry(usuarioEditar).State = System.Data.Entity.EntityState.Modified;
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
        /// Método que se encarga de eliminar un usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public bool eliminarUsuario(int idUsuario)
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    contexto.SGR_Usuarios.Remove(contexto.SGR_Usuarios.Where(x => x.ID_Usuario == idUsuario).FirstOrDefault());
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
        /// Método que se encarga de obtener la compañia seleccionada
        /// </summary>
        /// <param name="idCompañia"></param>
        /// <returns></returns>
        public List<SGR_Companias> listarCompaniaSeleccionada(int idCompañia)
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    return contexto.SGR_Companias.Where(x => x.ID_Compania == idCompañia).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
