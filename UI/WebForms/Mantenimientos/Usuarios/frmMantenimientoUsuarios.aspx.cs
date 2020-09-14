using BI.Mantenimientos;
using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.Utilitarios;

namespace UI.WebForms.Mantenimientos.Usuarios
{
    public partial class frmMantenimientoUsuarios : System.Web.UI.Page
    {
        Usuarios_BI usuarioBI = new Usuarios_BI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["agregarExitoso"] != null)
                {
                    Util.agregarMensajeSatisfaccion(this, "Se ha agregado correctamente el usuario");
                    Session.Remove("agregarExitoso");
                }
                else if (Session["editarExitoso"] != null)
                {
                    Util.agregarMensajeSatisfaccion(this, "Se ha editado correctamente el usuario");
                    Session.Remove("editarExitoso");
                }                
                tablaUsuarios.DataBind();
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Ha ocurrido un error a la hora de cargar la información");
            }
        }

        /// <summary>
        /// Evento click del botón consultar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuarioSeleccionado"] != null)
                {                    
                    Session["funcionalidad"] = 3;
                    Util.redirect("frmCRUDUsuarios");
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Debe seleccionar un registro");
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Se ha producido un error a la hora de consultar el usuario");
            }
        }
        /// <summary>
        /// Evento click del botón agregar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Util.redirect("frmCRUDUsuarios");
            Session["funcionalidad"] = 1;
        }
        /// <summary>
        /// Evento click del botón editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuarioSeleccionado"] != null)
                {
                    Session["funcionalidad"] = 2;
                    Util.redirect("frmCRUDUsuarios");
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Debe seleccionar un registro");
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Se ha producido un error a la hora de editar el usuario");
            }

        }
        /// <summary>
        /// Evento click del botón eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuarioSeleccionado"] != null)
                {
                    if (usuarioBI.eliminarUsuario((int)Session["usuarioSeleccionado"]))
                    {
                        Util.agregarMensajeSatisfaccion(this, "Se ha eliminado correctamente el usuario");
                        Session.Remove("usuarioSeleccionado");
                        tablaUsuarios.DataBind();
                    }
                    else
                    {
                        Util.agregarMensajeError(this, "Se ha producido un error a la hora de eliminar el usuario");
                    }
                }
                else
                {
                    Util.agregarMensajeAdvertencia(this, "Debe seleccionar un registro");
                }
            }
            catch (Exception)
            {
                Util.agregarMensajeError(this, "Se ha producido un error a la hora de eliminar el usuario");
            }
        }

        /// <summary>
        /// Evento de la selección de un row de la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tablaUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(tablaUsuarios, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        /// <summary>
        /// Evento del cambio de selección de un row de la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tablaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in tablaUsuarios.Rows)
            {
                if (row.RowIndex == tablaUsuarios.SelectedIndex)
                {
                    Session["usuarioSeleccionado"] = Convert.ToInt32(tablaUsuarios.SelectedValue);
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        /// <summary>
        /// Evento que se encarga de cargar la lista de la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tablaUsuarios_DataBinding(object sender, EventArgs e)
        {
            tablaUsuarios.DataSource = usuarioBI.listarUsuarios();
        }
    }
}