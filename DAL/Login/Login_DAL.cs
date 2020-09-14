using ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Login
{
    public class Login_DAL
    {
        /// <summary>
        /// Método que se encarga de validar el usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <returns></returns>
        public int validarIngreso(string usuario, string contrasena)
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    var usuValidar = contexto.SGR_Usuarios.Where(x => x.Nombre_Usuario == usuario
                    && x.Contrasena == contrasena && x.Estado).FirstOrDefault();
                    return usuValidar != null ? usuValidar.ID_Usuario : 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Método que se encarga de listar las compañias
        /// </summary>
        /// <returns></returns>
        public List<SGR_Companias> listarCompania()
        {
            try
            {
                using (SGREntities contexto = new SGREntities())
                {
                    return contexto.SGR_Companias.Where(x => x.Estado).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
