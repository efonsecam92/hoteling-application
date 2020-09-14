using System;
using System.Collections.Generic;
using DAL.Login;
using ENTITIES;

namespace BI.Login
{
    public class Login_BI
    {
        Login_DAL loginDal = new Login_DAL();

        /// <summary>
        /// Método que se encarga de valdiar los usuarios
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <returns></returns>
        public int validarIngreso(string usuario, string contrasena)
        {
            return loginDal.validarIngreso(usuario, contrasena);
        }

        /// <summary>
        /// Método que se encarga de listar las compañias
        /// </summary>
        /// <returns></returns>
        public List<SGR_Companias> listarCompania()
        {
            return loginDal.listarCompania();
        }
    }
}
