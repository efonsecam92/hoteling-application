using BI.Login;
using System;
using UI.Utilitarios;

namespace UI.WebForms.Base.Login
{
    public partial class Login : System.Web.UI.Page
    {
        Login_BI loginBI = new Login_BI();
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlCompania.DataBind();
        }

        /// <summary>
        /// Evento click del botón ingresar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                int idUsuario = loginBI.validarIngreso(txtUsuario.Text, txtClave.Text);
                if (idUsuario != 0)
                {
                    Session["usuarioIngresado"] = idUsuario;
                    Session["compañiaSeleccioanda"] = Convert.ToInt32(ddlCompania.SelectedValue);
                    Util.redirect("menu");
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Credenciales incorrectas");
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeAdvertencia(this, "Ha ocurrido un error a la hora de validar el usuario");
            }
        }

        protected void ddlCompania_DataBinding(object sender, EventArgs e)
        {
            try
            {
                ddlCompania.DataSource = loginBI.listarCompania();
            }
            catch (Exception ex)
            {
                Util.agregarMensajeAdvertencia(this, "Ha ocurrido un error a la hora de obtener las compañias");
            }
        }
    }
}